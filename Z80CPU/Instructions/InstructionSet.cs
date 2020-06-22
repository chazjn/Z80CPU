using System;
using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class InstructionSet
    {
        public List<Opcode> Opcodes { get; }

        public InstructionSet()
        {
            Opcodes = new List<Opcode>();
            Opcodes.AddRange(new Add().Opcodes);
        }

        public List<Opcode> Filter(IList<byte> bytes)
        {
            throw new NotImplementedException();

        }
    }
}
