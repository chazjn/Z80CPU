using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class DI : Instruction
    {
        public DI()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("DI", 0xF3, (z80) =>
                {
                    z80.InteruptsEnabled = false;
                })
            });
        }
    }
}
