using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class XOR_AF : Instruction_OLD
    {
        public XOR_AF() : base("XOR A", 0xAF)
        {
        }

        public override void Execute(Z80 z80)
        {
            z80.A.Value = (byte)(z80.A.Value ^ z80.A.Value);
        }
    }
}
