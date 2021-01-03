using System;
using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class IND : Instruction
    {
        public IND()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("IND", 0xED, 0xAA, (z80) => 
                {
                    var value = z80.Ports.GetByte(z80.C.Value);
                    z80.Memory.Set(z80.HL.Value, value);

                    z80.HL.Value--;
                    z80.B.Value--;

                    var random = new Random();
                    z80.F.Sign = random.Next(2) == 0;
                    z80.F.Zero = z80.B.Value == 0;
                    z80.F.HalfCarry = random.Next(2) == 0;
                    z80.F.ParityOrOverflow = random.Next(2) == 0;
                    z80.F.Sign = true;
                })
            });
        }
    }
}
