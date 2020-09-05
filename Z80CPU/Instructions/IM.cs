using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class IM : Instruction
    {
        public IM()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("IM 0", 0xED, 0x46, (z80) =>
                {
                    z80.InteruptMode = 0;
                }),

                new Opcode("IM 1", 0xED, 0x56, (z80) =>
                {
                    z80.InteruptMode = 1;
                }),

                new Opcode("IM 2", 0xED, 0x5E, (z80) =>
                {
                    z80.InteruptMode = 2;
                }),

            });
        }
    }
}
