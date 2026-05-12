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
                //new BIT(),
                //new JP(),
                //new LD()
            };
        }

        public IList<Instruction> GetCandidates(IList<byte> bytes)
        {
            var candidates = new List<Instruction>();

            foreach (var mnemonic in Mnemonics)
            {
                var matches = mnemonic.GetMatches(bytes);
                candidates.AddRange(matches);
            }

            return candidates;
        }
    }
}
