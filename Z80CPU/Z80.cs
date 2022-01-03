using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z80CPU.Instructions;
using Z80CPU.Registers;

namespace Z80CPU
{
    public class Z80
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
        public Registers.Flags F { get; private set; }
        public Registers.Flags F_ { get; private set; }

        public int InteruptMode { get; internal set; }
        public bool InteruptsEnabled { get; internal set;}

        internal InstructionSet InstructionSet { get; private set; }

        internal IList<byte> Buffer { get; }
        internal Opcode CurrentOpcode { get; private set; }

        public Z80(Memory memory, Ports ports)
        {
            Memory = memory;
            Ports = ports;

            F = new Registers.Flags();
            F_ = new Registers.Flags();
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

            Buffer = new List<byte>();

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
        }

        public void Tick()
        {
            //Get byte from memory and add to buffer
            var value = GetByte();
            Buffer.Add(value);

            //check if we have have complete command yet
            var opcodes = InstructionSet.GetOpcodeCandidates(Buffer);

            if (opcodes.Count == 0) //no instruction match - bad byte? excute a nop to skip over it
            {
                CurrentOpcode = new NOP().Opcodes.First();
                CurrentOpcode.Execute(this);
                Buffer.Clear();
            }
            else if (opcodes.Count == 1) 
            {
                // we have enough oprands, let's execute it
                if (opcodes.First().Values.Count() == Buffer.Count)
                {
                    CurrentOpcode = opcodes.First();
                    var cloneOfA = A.Clone(); //clone so we can compare value afterwards
                    var tStates = CurrentOpcode.Execute(this);
                    //

                    var flagsCalculator = new FlagsCalculator(this);
                    flagsCalculator.SetFlags(cloneOfA);

                    Buffer.Clear();
                }
                //nope, we have a match but we need to get some more bytes from memory
            }
        }

        internal byte GetByte()
        {
            var value = Memory.Get(PC.Value);
            PC.Increment();

            return value;
        }
    }
}
