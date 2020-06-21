using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public abstract class Instruction
    {
        public Instruction(Z80 z80)
        {
            var a = z80.A;
        }

        public abstract void Execute(Z80 z80);
    }
}
