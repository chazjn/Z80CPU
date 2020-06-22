using System;
using System.Collections.Generic;
using System.Text;
using Z80CPU.Instructions;
using Z80CPU.Registers;

namespace Z80CPU
{
    public class Z80
    {
        public Memory Memory { get; set; }

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

        public ProgramCounter PC { get; private set; }
        public Register16 SP { get; private set; }
        public Flag F { get; private set; }
        public Flag F_ { get; private set; }

        public InstructionSet InstructionSet { get; private set; }

        public IList<byte> Buffer { get; }

        public Z80(Memory memory)
        {
            Memory = memory;

            F = new Flag();
            F_ = new Flag();
            PC = new ProgramCounter();
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
        }

        public void Boot()
        {
            PC.Value = 0x0;
            SP.Value = 0xFFFF;

            Buffer.Clear();
            Cycle();
        }

        public void Cycle()
        {
            while (true)
            {
                //Get byte from memory and add to buffer
                var data = Memory.Get(PC.Value);
                Buffer.Add(data);

                //Increment the program counter
                PC.Increment();

                //check if we have have complete command yet
                var filteredInstructions = InstructionSet.Filter(Buffer);
                if (filteredInstructions.Count == 1)
                {
                    filteredInstructions[0].Execute(this);
                    Buffer.Clear();
                }
            }
        }
    }
}
