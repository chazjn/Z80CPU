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
                    Pop(z80, z80.B, z80.C);
                }),

                new Opcode("POP DE", 0xD1, (z80) =>
                {
                     Pop(z80, z80.D, z80.E);
                }),

                new Opcode("POP HL", 0xE1, (z80) =>
                {
                     Pop(z80, z80.H, z80.L);
                }),

                new Opcode("POP AF", 0x11, (z80) =>
                {
                     Pop(z80, z80.A, z80.F);
                }),
            });
        }

        private void Pop(Z80 z80, Register8 low, Register8 high)
        {
            var lowValue = z80.Memory.Get(z80.SP.Value);
            low.Value = lowValue;
            z80.SP.Value++;

            var highValue = z80.Memory.Get(z80.SP.Value);
            high.Value = highValue;
            z80.SP.Value++;
        }
    }
}
