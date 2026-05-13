using System.Collections.Generic;
using System.Linq;
using Z80CPU.Flags;

namespace Z80CPU
{
    public abstract class Mnemonic
    {
        public List<Instruction> Instructions { get; }

        public Mnemonic()
        {
            Instructions = new List<Instruction>();
            AddInstructions();
            SetOperation();
        }

        public IList<Instruction> GetMatches(IList<byte> bytes)
        {
            var matches = new List<Instruction>();

            foreach (var instruction in Instructions)
            {                
                // if we have too many bytes then this will never match
                if (bytes.Count > instruction.Values.Count)
                    continue;

                // we have less or equal byte so let's check if this is a contender
                var match = true;
                for (int i = 0; i < bytes.Count; i++)
                {
                    //first check if it is a 'Variable' byte
                    if (instruction.Values[i].IsVariable)
                        continue;

                    //second, compare the byte
                    if (instruction.Values[i].Value != bytes[i])
                    {
                        match = false;
                        break;
                    }
                }

                if(match)
                    matches.Add(instruction);
            }

            return matches;
        }

        protected abstract void AddInstructions();

        private void SetOperation()
        {
            var attribute = GetType()
                .GetCustomAttributes(typeof(FlagsCalculationAttribute), false)
                .Cast<FlagsCalculationAttribute>()
                .FirstOrDefault();

            if (attribute == null) return;

            foreach (var instruction in Instructions)
                instruction.Flags = attribute;
        }
    }
}
