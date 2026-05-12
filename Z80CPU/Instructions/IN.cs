using System.Collections.Generic;
using Z80CPU.Flags;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    [Flag(Name.Sign, Affect.DefaultCalculation)]
    [Flag(Name.Zero, Affect.DefaultCalculation)]
    [Flag(Name.HalfCarry, Affect.DefaultCalculation)]
    [Flag(Name.ParityOrOverflow, Affect.DefaultCalculation)]
    [Flag(Name.Subraction, Affect.Reset)]
    [Flag(Name.Carry, Affect.None)]
    public class IN : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("IN A, (C)", 0xED, 0x78, (z80) => { return SetRegister(z80, z80.A); }),
                new Instruction("IN B, (C)", 0xED, 0x40, (z80) => { return SetRegister(z80, z80.B); }),
                new Instruction("IN C, (C)", 0xED, 0x48, (z80) => { return SetRegister(z80, z80.C); }),
                new Instruction("IN D, (C)", 0xED, 0x50, (z80) => { return SetRegister(z80, z80.D); }),
                new Instruction("IN E, (C)", 0xED, 0x58, (z80) => { return SetRegister(z80, z80.E); }),
                new Instruction("IN H, (C)", 0xED, 0x60, (z80) => { return SetRegister(z80, z80.H); }),
                new Instruction("IN L, (C)", 0xED, 0x68, (z80) => { return SetRegister(z80, z80.L); }),

                new Instruction("IN A, (N)", 0xDB, EncodingByte.Variable, (z80) => { return SetA(z80); }).SetAllFlagsAffectToNone()
            });
        }

        public TStates SetRegister(Z80 z80, Register8 register)
        {
            var address = ByteHelper.CreateUShort(z80.B.Value, z80.C.Value);
            register.Value = z80.Ports.GetByte(address);
            return TStates.Count(12);
        }

        public TStates SetA(Z80 z80)
        {
            var low = z80.Buffer[1];
            var address = ByteHelper.CreateUShort(z80.A.Value, low);
            z80.A.Value = z80.Ports.GetByte(address);
            return TStates.Count(11);
        }
    }
}
