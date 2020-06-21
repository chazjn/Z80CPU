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

        public Register8 _A_ { get; private set; }
        public Register8 _B_ { get; private set; }
        public Register8 _C_ { get; private set; }
        public Register8 _D_ { get; private set; }
        public Register8 _E_ { get; private set; }
        public Register8 _H_ { get; private set; }
        public Register8 _L_ { get; private set; }


        public Register8 I { get; private set; }
        public Register8 R { get; private set; }

        public Register16 AF { get; private set; }
        public Register16 BC { get; private set; }
        public Register16 DE { get; private set; }
        public Register16 HL { get; private set; }

        public Register16 _AF_ { get; private set; }
        public Register16 _BC_ { get; private set; }
        public Register16 _DE_ { get; private set; }
        public Register16 _HL_ { get; private set; }

        public Register16 IX { get; private set; }
        public Register16 IY { get; private set; }

        public ProgramCounter PC { get; private set; }
        public Register16 SP { get; private set; }
        public Flag F { get; private set; }
        public Flag _F_ { get; private set; }

        public Instructions.Instructions InstructionSet { get; private set; }

        public Z80(Memory memory)
        {
            Memory = memory;

            F = new Flag();
            _F_ = new Flag();
            PC = new ProgramCounter();
            SP = new Register16("SP");

            A = new Register8("A");
            B = new Register8("B");
            C = new Register8("C");
            D = new Register8("D");
            E = new Register8("E");
            H = new Register8("H");
            L = new Register8("L");

            _A_ = new Register8("A");
            _B_ = new Register8("B");
            _C_ = new Register8("C");
            _D_ = new Register8("D");
            _E_ = new Register8("E");
            _H_ = new Register8("H");
            _L_ = new Register8("L");


            I = new Register8("I");
            R = new Register8("R");

            AF = new Register16(A, F);
            BC = new Register16(B, C);
            DE = new Register16(D, E);
            HL = new Register16(H, L);
            IX = new Register16("IX");
            IY = new Register16("IY");

            _AF_ = new Register16(_A_, _F_);
            _BC_ = new Register16(_B_, _C_);
            _DE_ = new Register16(_D_, _E_);
            _HL_ = new Register16(_H_, _L_);

            Instructions = new InstructionSet1();
        }

        public void Boot()
        {
            PC.Value = 0;
            Cycle();
        }

        public void Cycle()
        {
            var bytes = new List<byte>();

            while (true)
            {
                //Get byte from memory
                var data = Memory.Get(PC.Value);

                //Increment the program counter
                PC.Increment();

                //check if we have have complete command yet
                var filteredInstructions = Instructions.Filter(bytes);
                if (opcode != null || filteredInstructions.Count == 1)
                {
                    //oh good we do, so lets assign it to the local instruction
                    if(opcode == null)
                    {
                        opcode = filteredInstructions[0];
                    }

                    //and now check if we've also loaded the required parameters
                    if(opcode.ParametersRequired == opcode.Parameters.Count)
                    {
                        //run the code
                        opcode.Execute(this);

                        //clear out local variables
                        opcode = null;
                        bytes.Clear();
                    }
                }
            }
        }
    }
}
