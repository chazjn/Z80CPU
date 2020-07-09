using System.Collections.Generic;
using Z80CPU.Instructions;

namespace Z80CPU
{
    public class InstructionSet
    {
        public List<Instruction> Instructions { get; }

        public InstructionSet()
        {
            Instructions = new List<Instruction>
            {
                new ADD(),
                new BIT(),
                new JP(),
                new LD()
            };
        }

        public IList<Opcode> GetOpcodeCandidates(IList<byte> bytes)
        {
            var candidates = new List<Opcode>();

            foreach (var instruction in Instructions)
            {
                foreach (var opcode in instruction.Opcodes)
                {
                    if (opcode.IsMatch(bytes))
                    {
                        candidates.Add(opcode);
                    }
                }
            }

            return candidates;
        }
    }
}
