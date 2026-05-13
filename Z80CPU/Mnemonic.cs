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
            SetFlagsCalculationAttribute();
        }

        protected abstract void AddInstructions();

        private void SetFlagsCalculationAttribute()
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
