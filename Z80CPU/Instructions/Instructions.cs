using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class Instructions
    {
        public List<Opcode> Opcodes { get; }

        public Instructions()
        {
            Opcodes = new List<Opcode>();
            Opcodes.AddRange(new Add().Opcodes);
        }

        public List<Opcode> Filter(byte[] bytes)
        {


        }
    }
}
