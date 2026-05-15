using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class RL : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("RL A", 0xCB, 0x17, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RL B", 0xCB, 0x10, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RL C", 0xCB, 0x11, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RL D", 0xCB, 0x12, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RL E", 0xCB, 0x13, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RL H", 0xCB, 0x14, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RL L", 0xCB, 0x15, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RL (HL)", 0xCB, 0x16, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RL (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0x16, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RL (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0x16, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
            });
        }
    }
}
