using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class CCF : Instruction
    {
        public CCF()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("CCF", 0x3F, (z80) =>
                {
                    z80.F.HalfCarry = z80.F.Carry;
                    z80.F.Subtraction = false;
                    z80.F.Carry = !z80.F.Carry;
                })
            });
        }
    }
}
