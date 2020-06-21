using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class ADD_DD : Instruction_OLD
    {
        public ADD_DD() : base("ADD A, (IX + d)", 0xDD, 0x86)
        {
        }

        public override void Execute(Z80 z80)
        {

        }
    }
}
