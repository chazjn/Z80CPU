using System;
using System.Collections.Generic;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    public class POP : Instruction
    {
        //TODO: check low/high byte orders
        public POP()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("POP BC", 0xC1, (z80) =>
                {
                    Pop(z80, z80.BC);
                }),

                new Opcode("POP DE", 0xD1, (z80) =>
                {
                     Pop(z80, z80.DE);
                }),

                new Opcode("POP HL", 0xE1, (z80) =>
                {
                     Pop(z80, z80.HL);
                }),

                new Opcode("POP AF", 0x11, (z80) =>
                {
                     Pop(z80, z80.AF);
                }),

                new Opcode("POP IX", 0xDD, 0xE1, (z80) =>
                {
                     Pop(z80, z80.IX);
                }),

                new Opcode("POP IY", 0xDD, 0xE1, (z80) =>
                {
                    Pop(z80, z80.IY);
                })
            });
        }

        private void Pop(Z80 z80, Register16 register)
        {
            var lowValue = z80.Memory.Get(z80.SP.Value);
            z80.SP.Value++;

            var highValue = z80.Memory.Get(z80.SP.Value);
            z80.SP.Value++;

            register.Value = BitConverter.ToUInt16(new[] { highValue, lowValue }, 0);
        }
    }
}
