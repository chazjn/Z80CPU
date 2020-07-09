using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class LDIR : Instruction
    {
        public LDIR()
        {
            Opcodes.Add(new Opcode("LDIR", 0xED, 0xB0, (z80) =>
            {
                var value = z80.Memory.Get(z80.HL.Value);
                z80.Memory.Set(z80.DE.Value, value);

                z80.DE.Value++;
                z80.HL.Value++;
                z80.BC.Value--;

                z80.F.HalfCarry = false;
                z80.F.ParityOrOverflow = false;
                z80.F.Subtraction = false;

                if(z80.BC.Value != 0)
                {
                    z80.PC.Value--;
                    z80.PC.Value--;
                }
            }));
        }
    }
}
