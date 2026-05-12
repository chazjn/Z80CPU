using System.Collections.Generic;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    public class PUSH : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("PUSH BC", 0xC5, (z80) => { Push(z80, z80.BC); return TStates.Count(11); }),
                new Instruction("PUSH DE", 0xD5, (z80) => { Push(z80, z80.DE); return TStates.Count(11); }),
                new Instruction("PUSH HL", 0xE5, (z80) => { Push(z80, z80.HL); return TStates.Count(11); }),
                new Instruction("PUSH AF", 0xF5, (z80) => { Push(z80, z80.AF); return TStates.Count(11); }),
                new Instruction("PUSH IX", 0xDD, 0xE5, (z80) => { Push(z80, z80.IX); return TStates.Count(15); }),
                new Instruction("PUSH IY", 0xFD, 0xE5, (z80) => { Push(z80, z80.IY); return TStates.Count(15); }),
            });
        }

        private void Push(Z80 z80, Register16 register)
        {
            z80.SP.Value++;
            z80.Memory.Set(z80.SP.Value, register.High.Value);
            z80.SP.Value++;
            z80.Memory.Set(z80.SP.Value, register.Low.Value);
        }
    }
}
