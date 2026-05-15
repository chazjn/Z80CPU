using System.Collections.Generic;
using Z80CPU.Instructions;

namespace Z80CPU
{
    public class InstructionSet
    {
        public List<Mnemonic> Mnemonics { get; }

        public InstructionSet()
        {
            Mnemonics = new List<Mnemonic>
            {
                new ADD(),
                new ADC(),
                new ADC16(),
                new JR(),
                new HALT(),
            };
        }

        internal IList<Instruction> GetCandidates(InstructionBuffer buffer)
        {
            var candidates = new List<Instruction>();

            foreach (var mnemonic in Mnemonics)
            {
                foreach (var instruction in mnemonic.Instructions)
                {
                    // if we have too many bytes then this will never match
                    if (buffer.Count > instruction.Values.Count)
                        continue;

                    // we have less or equal byte so let's check if this is a contender
                    var match = true;
                    for (int i = 0; i < buffer.Count; i++)
                    {
                        //first check if it is a 'Variable' byte
                        if (instruction.Values[i].IsVariable)
                            continue;

                        //second, compare the byte
                        if (instruction.Values[i].Value != buffer[i])
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match)
                        candidates.Add(instruction);
                }
            }

            return candidates;
        }
    }
}
