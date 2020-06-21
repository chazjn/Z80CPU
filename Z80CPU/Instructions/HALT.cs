using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class HALT : Instruction_OLD
    {
        public HALT() : base("HALT", 0x76)
        {
        }

        public override void Execute(Z80 z80)
        {
            
        }
    }
}
