using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class JP
    {
        public IList<Opcode> Opcodes { get; }

        public JP()
        {
            Opcodes = new List<Opcode>();
        }
    }
}
