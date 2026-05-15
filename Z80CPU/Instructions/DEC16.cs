using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class DEC16 : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("DEC BC", 0x0B, z80 => { /* TODO */ return Execution.Result(TStates.Count(6)); }),
                new Instruction("DEC DE", 0x1B, z80 => { /* TODO */ return Execution.Result(TStates.Count(6)); }),
                new Instruction("DEC HL", 0x2B, z80 => { /* TODO */ return Execution.Result(TStates.Count(6)); }),
                new Instruction("DEC SP", 0x3B, z80 => { /* TODO */ return Execution.Result(TStates.Count(6)); }),
                new Instruction("DEC IX", 0xDD, 0x2B, z80 => { /* TODO */ return Execution.Result(TStates.Count(10)); }),
                new Instruction("DEC IY", 0xFD, 0x2B, z80 => { /* TODO */ return Execution.Result(TStates.Count(10)); }),
            });
        }
    }
}
