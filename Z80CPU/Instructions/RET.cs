using System;
using System.Collections.Generic;
using System.Text;

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
            });
        }

        private void Return(Z80 z80)
        {
            var low = z80.Memory.Get(z80.SP.Value);
            var high = z80.Memory.Get(z80.SP.Value++);

            z80.PC.Low.Value = low;
            z80.PC.High.Value = high;

            z80.SP.Value = z80.SP.Value++;
            z80.SP.Value = z80.SP.Value++;


        }
    }
}
