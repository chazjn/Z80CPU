using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class DI : Instruction_OLD
    {
        public DI() : base("DI", 0xF3)
        {
        }

        public override void Execute(Z80 z80)
        {
          //Does nothing yet because I have not implemented interrupt routines
        }
    }
}
