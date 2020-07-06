using System;
using System.Collections.Generic;
using System.Linq;
using Z80CPU.Instructions;

namespace Z80CPU
{
    public class InstructionSet
    {
        public List<Opcode> Opcodes { get; }

        public InstructionSet()
        {
            Opcodes = new List<Opcode>();
            Opcodes.AddRange(new ADD().Opcodes);
            Opcodes.AddRange(new BIT().Opcodes);
            Opcodes.AddRange(new JP().Opcodes);
            Opcodes.AddRange(new LD().Opcodes);
        }

        public IList<Opcode> GetOpcodeCandidates(IList<byte> bytes)
        {
            var candidates = new List<Opcode>();

            foreach (var opcode in Opcodes)
            {
                if (opcode.IsMatch(bytes))
                {
                    candidates.Add(opcode);
                }
            }

            return candidates;
        }
    }
}
