using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class DJNZ : Instruction
    {
        public DJNZ()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("DJNZ e", 0x10, (z80) => 
                {
                    z80.B.Value--;

                    if(z80.B.Value == 0)
                    {
                        var offset = z80.Memory.Get(z80.PC.Value);
                        var pc = z80.PC.Value + (sbyte)offset;
                        z80.PC.Value = (ushort)pc;
                    }
                    else
                    {
                        //increment PC to skip the offset
                        z80.PC.Increment();
                    }
                })
            });
        }
    }
}
