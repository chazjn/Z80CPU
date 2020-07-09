using System;
using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class JP : Instruction
    {
        public JP()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("JP NZ, pq", new[]{ new Oprand(0xC2), Oprand.Any, Oprand.Any }, (z80) =>
                {
                    if(z80.F.Zero == false)
                    {
                         Jump(z80);
                    }
                }),

                new Opcode("JP Z, pq", new[]{ new Oprand(0xCA), Oprand.Any, Oprand.Any }, (z80) =>
                {
                    if(z80.F.Zero == true)
                    {
                        Jump(z80);
                    }
                }),

                new Opcode("JP NC, pq", new[]{ new Oprand(0xD2), Oprand.Any, Oprand.Any }, (z80) =>
                {
                    if(z80.F.Carry == false)
                    {
                        Jump(z80);
                    }
                }),

                new Opcode("JP C, pq", new[]{ new Oprand(0xDA), Oprand.Any, Oprand.Any }, (z80) =>
                {
                    if(z80.F.Carry == true)
                    {
                        Jump(z80);
                    }
                }),

                new Opcode("JP PO, pq", new[]{ new Oprand(0xE2), Oprand.Any, Oprand.Any }, (z80) =>
                {
                    if(z80.F.ParityOrOverflow == false)
                    {
                        Jump(z80);
                    }
                }),

                new Opcode("JP PE, pq", new[]{ new Oprand(0xEA), Oprand.Any, Oprand.Any }, (z80) =>
                {
                    if(z80.F.ParityOrOverflow == true)
                    {
                        Jump(z80);
                    }
                }),

                new Opcode("JP P, pq", new[]{ new Oprand(0xF2), Oprand.Any, Oprand.Any }, (z80) =>
                {
                    if(z80.F.Sign == false)
                    {
                        Jump(z80);
                    }
                }),

                new Opcode("JP O, pq", new[]{ new Oprand(0xFA), Oprand.Any, Oprand.Any }, (z80) =>
                {
                    if(z80.F.Sign == true)
                    {
                        Jump(z80);
                    }
                }),
            }); 
        }

        private void Jump(Z80 z80)
        {
            var address = BitConverter.ToUInt16(new[] { z80.Buffer[2], z80.Buffer[1] }, 0);
            z80.PC.Value = address;
        }
    }
}
