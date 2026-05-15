using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class SLA : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("SLA A", 0xCB, 0x27, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SLA B", 0xCB, 0x20, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SLA C", 0xCB, 0x21, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SLA D", 0xCB, 0x22, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SLA E", 0xCB, 0x23, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SLA H", 0xCB, 0x24, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SLA L", 0xCB, 0x25, z80 => { /* TODO */ return Execution.Result(TStates.Count(8)); }),
                new Instruction("SLA (HL)", 0xCB, 0x26, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SLA (IX + d)", 0xDD, 0xCB, EncodingByte.Variable, 0x26, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("SLA (IY + d)", 0xFD, 0xCB, EncodingByte.Variable, 0x26, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
            });
        }
    }
}
