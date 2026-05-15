using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class RRC : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("RRC A", 0xCB, 0x0F, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RRC B", 0xCB, 0x08, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RRC C", 0xCB, 0x09, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RRC D", 0xCB, 0x0A, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RRC E", 0xCB, 0x0B, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RRC H", 0xCB, 0x0C, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RRC L", 0xCB, 0x0D, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("RRC (HL)", 0xCB, 0x0E, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("RRC (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0x0E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("RRC (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0x0E, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
            });
        }
    }
}
