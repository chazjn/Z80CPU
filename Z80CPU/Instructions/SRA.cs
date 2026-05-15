using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class SRA : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("SRA A", 0xCB, 0x2F, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRA B", 0xCB, 0x28, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRA C", 0xCB, 0x29, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRA D", 0xCB, 0x2A, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRA E", 0xCB, 0x2B, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRA H", 0xCB, 0x2C, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRA L", 0xCB, 0x2D, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRA (HL)", 0xCB, 0x2E, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SRA (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0x2E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SRA (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0x2E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
            });
        }
    }
}
