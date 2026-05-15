using System;
using System.Linq;
using System.Threading;
using Z80CPU.Flags;
using Z80CPU.Instructions;
using Z80CPU.Registers;

namespace Z80CPU
{
    public class Z80 : IZ80
    {
        public Memory Memory { get; set; }
        public Ports Ports { get; set; }

        public Register8 A { get; private set; }
        public Register8 B { get; private set; }
        public Register8 C { get; private set; }
        public Register8 D { get; private set; }
        public Register8 E { get; private set; }
        public Register8 H { get; private set; }
        public Register8 L { get; private set; }

        public Register8 A_ { get; private set; }
        public Register8 B_ { get; private set; }
        public Register8 C_ { get; private set; }
        public Register8 D_ { get; private set; }
        public Register8 E_ { get; private set; }
        public Register8 H_ { get; private set; }
        public Register8 L_ { get; private set; }


        public Register8 I { get; private set; }
        public Register8 R { get; private set; }

        public Register16 AF { get; private set; }
        public Register16 BC { get; private set; }
        public Register16 DE { get; private set; }
        public Register16 HL { get; private set; }

        public Register16 AF_ { get; private set; }
        public Register16 BC_ { get; private set; }
        public Register16 DE_ { get; private set; }
        public Register16 HL_ { get; private set; }

        public Register16 IX { get; private set; }
        public Register16 IY { get; private set; }

        public Register16 PC { get; private set; }
        public Register16 SP { get; private set; }
        public FlagsRegister F { get; private set; }
        public FlagsRegister F_ { get; private set; }

        public InterruptMode InteruptMode { get; internal set; }
        public bool InteruptsEnabled { get; internal set; }

        public bool IsHalted { get; private set; }

        public event EventHandler Halted;
        public event EventHandler Resumed;

        private bool _intPending;
        private bool _nmiPending;
        private bool _iff2;

        public void RaiseINT() => _intPending = true;
        public void RaiseNMI() => _nmiPending = true;

        public void Halt()
        {
            IsHalted = true;
            Halted?.Invoke(this, EventArgs.Empty);
        }

        public long TotalTStates { get; private set; }
        public int ClockFrequency { get; set; } = 3_500_000;
        public TimeSpan ElapsedTime => TimeSpan.FromSeconds((double)TotalTStates / ClockFrequency);

        private bool _throttleEnabled;
        private DateTime _wallClockStart = DateTime.UtcNow;

        public bool ThrottleEnabled
        {
            get => _throttleEnabled;
            set
            {
                _throttleEnabled = value;
                if (value)
                    _wallClockStart = DateTime.UtcNow - ElapsedTime; // re-sync so no catch-up backlog
            }
        }

        internal InstructionSet InstructionSet { get; private set; }

        internal InstructionBuffer Buffer { get; }
        internal Instruction CurrentInstruction { get; private set; }

        public Z80(Memory memory, Ports ports)
        {
            Memory = memory;
            Ports = ports;

            F = new FlagsRegister();
            F_ = new FlagsRegister();
            PC = new Register16("PC");
            SP = new Register16("SP");

            A = new Register8("A");
            B = new Register8("B");
            C = new Register8("C");
            D = new Register8("D");
            E = new Register8("E");
            H = new Register8("H");
            L = new Register8("L");

            A_ = new Register8("A");
            B_ = new Register8("B");
            C_ = new Register8("C");
            D_ = new Register8("D");
            E_ = new Register8("E");
            H_ = new Register8("H");
            L_ = new Register8("L");

            I = new Register8("I");
            R = new Register8("R");

            AF = new Register16(A, F);
            BC = new Register16(B, C);
            DE = new Register16(D, E);
            HL = new Register16(H, L);
            IX = new Register16("IX");
            IY = new Register16("IY");

            AF_ = new Register16(A_, F_);
            BC_ = new Register16(B_, C_);
            DE_ = new Register16(D_, E_);
            HL_ = new Register16(H_, L_);

            InstructionSet = new InstructionSet();

            Buffer = new InstructionBuffer();

            PC.Value = 0x0;
            SP.Value = 0XFFFF;

            Buffer.Clear();
        }

        public void Reset()
        {
            PC.Value = 0;
            I.Value = 0;
            R.Value = 0;
            InteruptsEnabled = false;
            InteruptMode = 0;
            TotalTStates = 0;
            _wallClockStart = DateTime.UtcNow;
            IsHalted = false;
            _intPending = false;
            _nmiPending = false;
        }

        public Execution Tick()
        {
            var value = GetByte();
            Buffer.Add(value);

            var candidateInstructions = InstructionSet.GetCandidates(Buffer);

            if (candidateInstructions.Count == 0)
            {
                CurrentInstruction = new NOP().Instructions.First();
                var execution = CurrentInstruction.Execute(this);
                Buffer.Clear();
                return execution;
            }
            else if (candidateInstructions.Count == 1)
            {
                if (candidateInstructions.First().Values.Count() == Buffer.Count)
                {
                    CurrentInstruction = candidateInstructions.First();
                    var execution = CurrentInstruction.Execute(this);
                    new FlagsCalculator(F).SetFlags(execution, CurrentInstruction);
                    Buffer.Clear();
                    return execution;
                }
            }

            return null; // mid-instruction, more bytes needed
        }

        public Execution Step()
        {
            Execution execution;

            if (IsHalted)
            {
                execution = new NOP().Instructions.First().Execute(this);
                TotalTStates += execution.TStates.Value;
            }
            else
            {
                do { execution = Tick(); } while (execution == null);
                TotalTStates += execution.TStates.Value;
            }

            CheckInterrupts();
            Throttle();

            return execution;
        }

        private void CheckInterrupts()
        {
            if (_nmiPending)
            {
                _nmiPending = false;
                ServiceNMI();
            }
            else if (_intPending && InteruptsEnabled)
            {
                _intPending = false;
                ServiceINT();
            }
        }

        private void ServiceNMI()
        {
            _iff2 = InteruptsEnabled;
            InteruptsEnabled = false;
            PushPC();
            PC.Value = 0x0066;
            TotalTStates += 11;
            ExitHalt();
        }

        private void ServiceINT()
        {
            InteruptsEnabled = false;
            PushPC();
            switch (InteruptMode)
            {
                case InterruptMode.Mode2:
                    var vectorAddr = (ushort)((I.Value << 8) | 0xFF);
                    PC.Value = (ushort)(Memory.Get(vectorAddr) | (Memory.Get((ushort)(vectorAddr + 1)) << 8));
                    TotalTStates += 19;
                    break;
                default: // Mode0 treated as Mode1
                    PC.Value = 0x0038;
                    TotalTStates += 13;
                    break;
            }
            ExitHalt();
        }

        private void PushPC()
        {
            SP.Decrement();
            Memory.Set(SP, PC.High.Value);
            SP.Decrement();
            Memory.Set(SP, PC.Low.Value);
        }

        private void ExitHalt()
        {
            if (!IsHalted) return;
            IsHalted = false;
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        private void Throttle()
        {
            if (!_throttleEnabled) return;
            var ahead = ElapsedTime - (DateTime.UtcNow - _wallClockStart);
            if (ahead > TimeSpan.FromMilliseconds(2))
                Thread.Sleep(ahead - TimeSpan.FromMilliseconds(1));
            while (ElapsedTime > DateTime.UtcNow - _wallClockStart) { }
        }

        private byte GetByte()
        {
            var value = Memory.Get(PC.Value);
            PC.Increment();

            return value;
        }
    }
}
