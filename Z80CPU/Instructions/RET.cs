using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class RET : Instruction
    {
        public RET()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("RET", 0xC9, z80 =>
                {
                    Return(z80);
                }),

                new Opcode("RET NZ", 0xC0, z80 =>
                {
                    if(z80.F.Zero == false)
                    {
                        Return(z80);
                    }
                }),

                new Opcode("RET Z", 0xC8, z80 =>
                {
                    if (z80.F.Zero)
                    {
                        Return(z80);
                    }                    
                }),

                new Opcode("RET NC", 0xD0, z80 =>
                {
                    if (z80.F.Carry == false)
                    {
                        Return(z80);
                    }
                }),

                new Opcode("RET C", 0xD8, z80 =>
                {
                   if (z80.F.Carry)
                    {
                        Return(z80);
                    }
                }),

                new Opcode("RET PO", 0xE0, z80 =>
                {
                    if (z80.F.ParityOrOverflow == false)
                    {
                        Return(z80);
                    }
                }),

                new Opcode("RET PE", 0xE8, z80 =>
                {
                    if (z80.F.ParityOrOverflow)
                    {
                        Return(z80);
                    }
                }),

                new Opcode("RET P", 0xF0, z80 =>
                {
                    if (z80.F.Sign == false)
                    {
                        Return(z80);
                    }
                }),

                new Opcode("RET M", 0xF8, z80 =>
                {
                    if (z80.F.Sign)
                    {
                        Return(z80);
                    }
                }),

            });
        }

        private void Return(Z80 z80)
        {
            var low = z80.Memory.Get(z80.SP.Value);
            var high = z80.Memory.Get(z80.SP.Value++);

            z80.PC.Low.Value = low;
            z80.PC.High.Value = high;

            z80.SP.Increment();
            z80.SP.Increment();
        }
    }
}
