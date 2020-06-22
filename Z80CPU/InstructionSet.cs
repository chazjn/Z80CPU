using System;
using System.Collections.Generic;
using Z80CPU.Instructions;

namespace Z80CPU
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
