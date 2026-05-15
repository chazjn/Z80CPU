using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class RST : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("RST 00H", 0xC7, z80 => { /* TODO: push PC, jump to 0x0000 */ return Execution.Result(TStates.Count(11)); }),
                new Instruction("RST 08H", 0xCF, z80 => { /* TODO: push PC, jump to 0x0008 */ return Execution.Result(TStates.Count(11)); }),
                new Instruction("RST 10H", 0xD7, z80 => { /* TODO: push PC, jump to 0x0010 */ return Execution.Result(TStates.Count(11)); }),
                new Instruction("RST 18H", 0xDF, z80 => { /* TODO: push PC, jump to 0x0018 */ return Execution.Result(TStates.Count(11)); }),
                new Instruction("RST 20H", 0xE7, z80 => { /* TODO: push PC, jump to 0x0020 */ return Execution.Result(TStates.Count(11)); }),
                new Instruction("RST 28H", 0xEF, z80 => { /* TODO: push PC, jump to 0x0028 */ return Execution.Result(TStates.Count(11)); }),
                new Instruction("RST 30H", 0xF7, z80 => { /* TODO: push PC, jump to 0x0030 */ return Execution.Result(TStates.Count(11)); }),
                new Instruction("RST 38H", 0xFF, z80 => { /* TODO: push PC, jump to 0x0038 */ return Execution.Result(TStates.Count(11)); }),
            });
        }
    }
}
