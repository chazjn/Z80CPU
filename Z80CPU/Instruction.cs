using System;
using System.Collections.Generic;
using System.Linq;
using Z80CPU.Flags;

namespace Z80CPU
{
    public abstract class Instruction
    {
        public List<Opcode> Opcodes { get; }

        public Instruction()
        {
            Opcodes = new List<Opcode>();
            AddOpcodes();
            SetFlagAffects();
        }

        public IList<Opcode> GetMatches(IList<byte> bytes)
        {
            var matches = new List<Opcode>();

            foreach (var opcode in Opcodes)
            {
                // if we have too many bytes then this will never match
                if (bytes.Count > opcode.Values.Count)
                    continue;

                // we have less or equal byte so let's check if this is a contender
                for (int i = 0; i < bytes.Count; i++)
                {
                    //first check if it is an 'Any' byte
                    if (opcode.Values[i].IsAny)
                        continue;

                    //second, compare the byte
                    if (opcode.Values[i].Value != bytes[i])
                        continue;
                }

                matches.Add(opcode);
            }

            return matches;
        }

        protected abstract void AddOpcodes();

        private void SetFlagAffects()
        {
            var customAttributes = GetType().GetCustomAttributes(false);    
            var flagAttributes = Array.ConvertAll(customAttributes, x => (FlagAttribute)x);

            foreach (var opcode in Opcodes)
            {
                opcode.SignAffect = opcode.SignAffect ?? GetFlagAffect(Name.Sign, flagAttributes);
                opcode.ZeroAffect = opcode.ZeroAffect ?? GetFlagAffect(Name.Zero, flagAttributes);
                opcode.HalfCarryAffect = opcode.HalfCarryAffect ?? GetFlagAffect(Name.HalfCarry, flagAttributes);
                opcode.ParityOrOverflowAffect = opcode.ParityOrOverflowAffect ?? GetFlagAffect(Name.ParityOrOverflow, flagAttributes);
                opcode.SubtractionAffect = opcode.SubtractionAffect ?? GetFlagAffect(Name.Subraction, flagAttributes);
                opcode.CarryAffect = opcode.CarryAffect ?? GetFlagAffect(Name.Carry, flagAttributes);
            }
        }

        private Affect GetFlagAffect(Name name, FlagAttribute[] flagAttributes)
        {
            var value = flagAttributes.Where(x => x.Name == name).FirstOrDefault();
            return value?.Affect ?? Affect.None;
        }
    }
}
