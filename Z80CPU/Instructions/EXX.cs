using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class EXX : Instruction
    {
        public EXX()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("EXX", 0xD9, (z80) =>
                {
                    var bc = z80.BC.Value;
                    var de = z80.DE.Value;
                    var hl = z80.HL.Value;

                    z80.BC.Value = z80.BC_.Value;
                    z80.DE.Value = z80.DE_.Value;
                    z80.HL.Value = z80.HL_.Value;

                    z80.BC_.Value = bc;
                    z80.DE_.Value = de;
                    z80.HL_.Value = hl;
                })
            });
        }
    }
}
