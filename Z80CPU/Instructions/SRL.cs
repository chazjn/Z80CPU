using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class SRL : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("SRL A", 0xCB, 0x3F, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRL B", 0xCB, 0x38, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRL C", 0xCB, 0x39, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRL D", 0xCB, 0x3A, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRL E", 0xCB, 0x3B, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRL H", 0xCB, 0x3C, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRL L", 0xCB, 0x3D, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SRL (HL)", 0xCB, 0x3E, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SRL (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0x3E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SRL (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0x3E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
            });
        }
    }
}
