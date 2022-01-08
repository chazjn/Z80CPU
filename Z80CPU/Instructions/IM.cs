using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Affect.None)]
    public class IM : Instruction
    {   
        protected override void AddOpcodes()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("IM 0", 0xED, 0x46, (z80) => { z80.InteruptMode = InterruptMode.Mode0; return TStates.Count(8); }),
                new Opcode("IM 1", 0xED, 0x56, (z80) => { z80.InteruptMode = InterruptMode.Mode1; return TStates.Count(8); }),
                new Opcode("IM 2", 0xED, 0x5E, (z80) => { z80.InteruptMode = InterruptMode.Mode2; return TStates.Count(8); }),
            });
        }
    }
}
