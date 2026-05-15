using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class RR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("RR A", 0xCB, 0x1F, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RR B", 0xCB, 0x18, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RR C", 0xCB, 0x19, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RR D", 0xCB, 0x1A, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RR E", 0xCB, 0x1B, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RR H", 0xCB, 0x1C, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RR L", 0xCB, 0x1D, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RR (HL)", 0xCB, 0x1E, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RR (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0x1E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RR (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0x1E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
            });
        }
    }
}
