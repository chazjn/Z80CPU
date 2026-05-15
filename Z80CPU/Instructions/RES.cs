using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class RES : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("RES 0, B", 0xCB, 0x80, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 0, C", 0xCB, 0x81, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 0, D", 0xCB, 0x82, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 0, E", 0xCB, 0x83, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 0, H", 0xCB, 0x84, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 0, L", 0xCB, 0x85, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 0, (HL)", 0xCB, 0x86, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RES 0, A", 0xCB, 0x87, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("RES 1, B", 0xCB, 0x88, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 1, C", 0xCB, 0x89, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 1, D", 0xCB, 0x8A, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 1, E", 0xCB, 0x8B, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 1, H", 0xCB, 0x8C, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 1, L", 0xCB, 0x8D, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 1, (HL)", 0xCB, 0x8E, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RES 1, A", 0xCB, 0x8F, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("RES 2, B", 0xCB, 0x90, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 2, C", 0xCB, 0x91, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 2, D", 0xCB, 0x92, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 2, E", 0xCB, 0x93, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 2, H", 0xCB, 0x94, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 2, L", 0xCB, 0x95, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 2, (HL)", 0xCB, 0x96, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RES 2, A", 0xCB, 0x97, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("RES 3, B", 0xCB, 0x98, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 3, C", 0xCB, 0x99, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 3, D", 0xCB, 0x9A, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 3, E", 0xCB, 0x9B, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 3, H", 0xCB, 0x9C, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 3, L", 0xCB, 0x9D, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 3, (HL)", 0xCB, 0x9E, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RES 3, A", 0xCB, 0x9F, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("RES 4, B", 0xCB, 0xA0, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 4, C", 0xCB, 0xA1, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 4, D", 0xCB, 0xA2, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 4, E", 0xCB, 0xA3, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 4, H", 0xCB, 0xA4, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 4, L", 0xCB, 0xA5, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 4, (HL)", 0xCB, 0xA6, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RES 4, A", 0xCB, 0xA7, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("RES 5, B", 0xCB, 0xA8, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 5, C", 0xCB, 0xA9, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 5, D", 0xCB, 0xAA, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 5, E", 0xCB, 0xAB, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 5, H", 0xCB, 0xAC, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 5, L", 0xCB, 0xAD, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 5, (HL)", 0xCB, 0xAE, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RES 5, A", 0xCB, 0xAF, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("RES 6, B", 0xCB, 0xB0, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 6, C", 0xCB, 0xB1, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 6, D", 0xCB, 0xB2, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 6, E", 0xCB, 0xB3, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 6, H", 0xCB, 0xB4, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 6, L", 0xCB, 0xB5, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 6, (HL)", 0xCB, 0xB6, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RES 6, A", 0xCB, 0xB7, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("RES 7, B", 0xCB, 0xB8, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 7, C", 0xCB, 0xB9, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 7, D", 0xCB, 0xBA, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 7, E", 0xCB, 0xBB, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 7, H", 0xCB, 0xBC, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 7, L", 0xCB, 0xBD, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RES 7, (HL)", 0xCB, 0xBE, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RES 7, A", 0xCB, 0xBF, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("RES 0, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0x86, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 1, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0x8E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 2, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0x96, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 3, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0x9E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 4, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xA6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 5, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xAE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 6, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xB6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 7, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xBE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),

                new Instruction("RES 0, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0x86, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 1, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0x8E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 2, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0x96, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 3, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0x9E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 4, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xA6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 5, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xAE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 6, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xB6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RES 7, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xBE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
            });
        }
    }
}
