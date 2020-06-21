using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class BIT_DD : Instruction_OLD
    {
        public BIT_DD() : base("BIT b, (IX _ d)", 0xDD, 0xCB, 2)
        {
        }

        public override void Execute(Z80 z80)
        {

        }
    }
}
