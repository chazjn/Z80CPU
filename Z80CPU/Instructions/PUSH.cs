using System.Collections.Generic;
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

                new Opcode("PUSH IX", 0xDD, 0xE5, (z80) =>
                {
                    Push(z80, z80.IX);
                }),

                new Opcode("PUSH IY", 0xFD, 0xE5, (z80) =>
                {
                    Push(z80, z80.IY);
                }),
            });
        }

        protected override void AddOpcodes()
        {
            throw new System.NotImplementedException();
        }

        private void Push(Z80 z80, Register16 register)
        {
            z80.SP.Value--;
            z80.Memory.Set(z80.SP.Value, register.High.Value);
            z80.SP.Value--;
            z80.Memory.Set(z80.SP.Value, register.Low.Value);
        }
    }
}
