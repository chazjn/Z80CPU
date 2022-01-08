using System.Collections.Generic;
using Z80CPU.Flags;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    [Flag(Affect.None)]
    public class EX : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("EX AF, AF'", 0x08, (z80) => { return ExchangeRegisters(z80.AF, z80.AF_); }),
                new Opcode("EX DE, HL",  0xEB, (z80) => { return ExchangeRegisters(z80.DE, z80.HL); }),

                new Opcode("EX (SP), HL", 0xE3,       (z80) => { return ExchangeStackPointer(z80, z80.HL); }),
                new Opcode("EX (SP), IX", 0xDD, 0xE3, (z80) => { return ExchangeStackPointer(z80, z80.IX); }),
                new Opcode("EX (SP), IY", 0xFD, 0xE3, (z80) => { return ExchangeStackPointer(z80, z80.IY); })
            });
        }

        private TStates ExchangeRegisters(Register16 register1, Register16 register2)
        {
            var register1Value = register1.Value;
            register1.Value = register2.Value;
            register2.Value = register1Value;
            return TStates.Count(4);
        }

        private TStates ExchangeStackPointer(Z80 z80, Register16 register)
        {
            var low = register.Low.Value;
            var high = register.High.Value;
            var sp = z80.SP.Value;

            register.Low.Value = z80.Memory.Get(sp);
            register.High.Value = z80.Memory.Get((ushort)(sp + 1));

            z80.Memory.Set(sp, low);
            z80.Memory.Set((ushort)(sp + 1), high);

            return TStates.Count(19);
        }
    }
}
