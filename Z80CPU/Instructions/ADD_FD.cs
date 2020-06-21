using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class ADD_FD : Instruction_OLD
    {
        public ADD_FD() : base("ADD A, (IY + d)", 0xFD, 0x86)
        {
        }

        public override void Execute(Z80 z80)
        {
            
        }
    }
}
