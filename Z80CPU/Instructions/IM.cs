using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Affect.None)]
    public class IM : Mnemonic
    {   
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("IM 0", 0xED, 0x46, (z80) => { z80.InteruptMode = InterruptMode.Mode0; return TStates.Count(8); }),
                new Instruction("IM 1", 0xED, 0x56, (z80) => { z80.InteruptMode = InterruptMode.Mode1; return TStates.Count(8); }),
                new Instruction("IM 2", 0xED, 0x5E, (z80) => { z80.InteruptMode = InterruptMode.Mode2; return TStates.Count(8); }),
            });
        }
    }
}
