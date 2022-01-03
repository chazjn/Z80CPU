using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class JR : Instruction
    {
        public JR()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("JR NZ, e", 0x20, Oprand.Any, (z80) =>
                {
                    if(z80.F.Zero == false)
                    {
                        Jump(z80);
                    }
                }),

                new Opcode("JR Z, e", 0x28, Oprand.Any, (z80) =>
                {
                    if(z80.F.Zero == true)
                    {
                        Jump(z80);
                    }
                }),

                new Opcode("JR NC, e", 0x30, Oprand.Any, (z80) =>
                {
                    if(z80.F.Carry == false)
                    {
                        Jump(z80);
                    }
                }),

                new Opcode("JR C, e", 0x38, Oprand.Any, (z80) =>
                {
                    if(z80.F.Carry == true)
                    {
                        Jump(z80);
                    }
                }),

                new Opcode("JR e", 0x18, Oprand.Any, (z80) =>
                {
                    Jump(z80);
                }),
            });
        }

        protected override void AddOpcodes()
        {
            throw new NotImplementedException();
        }

        private void Jump(Z80 z80)
        {
            //TODO: test 2s-complement arithmitic
            z80.PC.Value = (ushort)(z80.PC.Value + z80.Buffer[1]);
        }
    }
}
