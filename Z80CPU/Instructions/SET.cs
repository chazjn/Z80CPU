using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class SET : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("SET 0, B", 0xCB, 0xC0, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 0, C", 0xCB, 0xC1, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 0, D", 0xCB, 0xC2, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 0, E", 0xCB, 0xC3, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 0, H", 0xCB, 0xC4, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 0, L", 0xCB, 0xC5, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 0, (HL)", 0xCB, 0xC6, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SET 0, A", 0xCB, 0xC7, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("SET 1, B", 0xCB, 0xC8, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 1, C", 0xCB, 0xC9, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 1, D", 0xCB, 0xCA, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 1, E", 0xCB, 0xCB, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 1, H", 0xCB, 0xCC, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 1, L", 0xCB, 0xCD, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 1, (HL)", 0xCB, 0xCE, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SET 1, A", 0xCB, 0xCF, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("SET 2, B", 0xCB, 0xD0, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 2, C", 0xCB, 0xD1, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 2, D", 0xCB, 0xD2, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 2, E", 0xCB, 0xD3, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 2, H", 0xCB, 0xD4, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 2, L", 0xCB, 0xD5, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 2, (HL)", 0xCB, 0xD6, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SET 2, A", 0xCB, 0xD7, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("SET 3, B", 0xCB, 0xD8, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 3, C", 0xCB, 0xD9, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 3, D", 0xCB, 0xDA, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 3, E", 0xCB, 0xDB, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 3, H", 0xCB, 0xDC, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 3, L", 0xCB, 0xDD, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 3, (HL)", 0xCB, 0xDE, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SET 3, A", 0xCB, 0xDF, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("SET 4, B", 0xCB, 0xE0, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 4, C", 0xCB, 0xE1, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 4, D", 0xCB, 0xE2, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 4, E", 0xCB, 0xE3, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 4, H", 0xCB, 0xE4, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 4, L", 0xCB, 0xE5, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 4, (HL)", 0xCB, 0xE6, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SET 4, A", 0xCB, 0xE7, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("SET 5, B", 0xCB, 0xE8, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 5, C", 0xCB, 0xE9, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 5, D", 0xCB, 0xEA, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 5, E", 0xCB, 0xEB, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 5, H", 0xCB, 0xEC, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 5, L", 0xCB, 0xED, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 5, (HL)", 0xCB, 0xEE, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SET 5, A", 0xCB, 0xEF, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("SET 6, B", 0xCB, 0xF0, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 6, C", 0xCB, 0xF1, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 6, D", 0xCB, 0xF2, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 6, E", 0xCB, 0xF3, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 6, H", 0xCB, 0xF4, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 6, L", 0xCB, 0xF5, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 6, (HL)", 0xCB, 0xF6, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SET 6, A", 0xCB, 0xF7, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("SET 7, B", 0xCB, 0xF8, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 7, C", 0xCB, 0xF9, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 7, D", 0xCB, 0xFA, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 7, E", 0xCB, 0xFB, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 7, H", 0xCB, 0xFC, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 7, L", 0xCB, 0xFD, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SET 7, (HL)", 0xCB, 0xFE, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SET 7, A", 0xCB, 0xFF, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),

                new Instruction("SET 0, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xC6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 1, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xCE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 2, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xD6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 3, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xDE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 4, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xE6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 5, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xEE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 6, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xF6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 7, (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0xFE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),

                new Instruction("SET 0, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xC6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 1, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xCE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 2, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xD6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 3, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xDE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 4, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xE6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 5, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xEE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 6, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xF6, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SET 7, (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0xFE, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
            });
        }
    }
}
