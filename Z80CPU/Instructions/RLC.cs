using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class RLC : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("RLC A", 0xCB, 0x07, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RLC B", 0xCB, 0x00, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RLC C", 0xCB, 0x01, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RLC D", 0xCB, 0x02, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RLC E", 0xCB, 0x03, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RLC H", 0xCB, 0x04, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RLC L", 0xCB, 0x05, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RLC (HL)", 0xCB, 0x06, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RLC (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0x06, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RLC (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0x06, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
            });
        }
    }
}
