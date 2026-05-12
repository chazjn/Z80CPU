using System;
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
            SetFlagAffects();
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
                for (int i = 0; i < bytes.Count; i++)
                {
                    //first check if it is a 'Variable' byte
                    if (instruction.Values[i].IsVariable)
                        continue;

                    //second, compare the byte
                    if (instruction.Values[i].Value != bytes[i])
                        continue;
                }

                matches.Add(instruction);
            }

            return matches;
        }

        protected abstract void AddInstructions();

        private void SetFlagAffects()
        {
            var customAttributes = GetType().GetCustomAttributes(false);    
            var flagAttributes = Array.ConvertAll(customAttributes, x => (FlagAttribute)x);

            foreach (var instruction in Instructions)
            {
                instruction.SignAffect = instruction.SignAffect ?? GetFlagAffect(Name.Sign, flagAttributes);
                instruction.ZeroAffect = instruction.ZeroAffect ?? GetFlagAffect(Name.Zero, flagAttributes);
                instruction.HalfCarryAffect = instruction.HalfCarryAffect ?? GetFlagAffect(Name.HalfCarry, flagAttributes);
                instruction.ParityOrOverflowAffect = instruction.ParityOrOverflowAffect ?? GetFlagAffect(Name.ParityOrOverflow, flagAttributes);
                instruction.SubtractionAffect = instruction.SubtractionAffect ?? GetFlagAffect(Name.Subraction, flagAttributes);
                instruction.CarryAffect = instruction.CarryAffect ?? GetFlagAffect(Name.Carry, flagAttributes);
            }
        }

        private Affect GetFlagAffect(Name name, FlagAttribute[] flagAttributes)
        {
            var value = flagAttributes.Where(x => x.Name == name).FirstOrDefault();
            return value?.Affect ?? Affect.None;
        }
    }
}
