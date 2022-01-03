using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class LD : Instruction
    {
        public LD()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("LD A, n", 0x3E, Oprand.Any, (z80) =>
                {
                    z80.A.Value = z80.Buffer[1];
                }),
                
                new Opcode("LD (BC), A", 0x02, (z80) => 
                {
                    var bc = z80.BC.Value;
                    var a = z80.A.Value;
                    z80.Memory.Set(bc, a);
                }),

                new Opcode("LD (DE), A", 0x12, (z80) =>
                {
                    var de = z80.DE.Value;
                    var a = z80.A.Value;
                    z80.Memory.Set(de, a);
                }),

                new Opcode("LD (HL), n", 0x36, Oprand.Any, (z80) =>
                {
                    var hl = z80.HL.Value;
                    var value = z80.Buffer[1];
                    z80.Memory.Set(hl, value);
                }),

                new Opcode("LD (HL), B", 0x70, (z80) =>
                {
                    var hl = z80.HL.Value;
                    var value = z80.Memory.Get(hl);
                    z80.BC.Value = value;
                })
            });
        }

        protected override void AddOpcodes()
        {
            throw new NotImplementedException();
        }
    }
}
