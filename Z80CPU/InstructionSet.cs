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
            Opcodes.AddRange(new Add().Opcodes);
        }

        public IList<Opcode> GetOpcodeCandidates(IList<byte> bytes)
        {
            //initially add all the opcodes to the candidate list 
            var candidates = new List<Opcode>(Opcodes);

            foreach (var opcode in Opcodes)
            {
                //skip if the byte count is not the same
                if(opcode.Bytes.Count() != bytes.Count)
                {
                    candidates.Remove(opcode);
                    continue;
                }

                //same byte count so check the bytes are the same
                for (int i = 0; i < bytes.Count; i++)
                {
                    //skip comparing parameter bytes
                    if (opcode.Bytes[i].IsParameter)
                    {
                        continue;
                    }

                    //break if the bytes don't match
                    if (opcode.Bytes[i].Value != bytes[i])
                    {
                        candidates.Remove(opcode);
                        break;
                    }
                }
            }

            return candidates;
        }
    }
}
