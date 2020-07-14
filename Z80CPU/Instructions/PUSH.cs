using System;
using System.Collections.Generic;
using System.Text;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    public class PUSH : Instruction
    {
        public PUSH()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("PUSH BC", 0xC5, (z80) =>
                {
                    Push(z80, z80.BC);
                }),

                new Opcode("PUSH DE", 0xD5, (z80) =>
                {
                    Push(z80, z80.DE);
                }),

                new Opcode("PUSH HL", 0xE5, (z80) =>
                {
                    Push(z80, z80.HL);
                }),

                new Opcode("PUSH AF", 0xF5, (z80) =>
                {
                    Push(z80, z80.AF);
                }),
            });
        }

        private void Push(Z80 z80, Register16 register)
        {
            //TODO: Finish this
            z80.SP.Value--;
            //var high = z80.Memory.Get()
        }
    }
}
