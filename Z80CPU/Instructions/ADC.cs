using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class ADC : Instruction
    {
        public ADC()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("ADC A, A", 0x8F, z80 =>
                {
                }),
                
                new Opcode("ADC A, B", 0x88, z80 =>
                {
                }),

                new Opcode("ADC A, C", 0x89, z80 =>
                {
                }),

                new Opcode("ADC A, D", 0x8A, z80 =>
                {
                }),

                new Opcode("ADC A, E", 0x8B, z80 =>
                {
                }),

                new Opcode("ADC A, H", 0x8C, z80 =>
                {
                }),

                new Opcode("ADC A, L", 0x8D, z80 =>
                {
                }),

                new Opcode("ADC A, n", 0xCE, Oprand.Any, z80 =>
                {
                }),

                new Opcode("ADC A, (HL)", 0x8E, z80 =>
                {
                }),
                
                new Opcode("ADC A, (IX + d)", 0xDD, 0x8E, Oprand.Any, z80 =>
                {
                }),

                new Opcode("ADC A, (IY + d)", 0xFD, 0x8E, Oprand.Any, z80 =>
                {
                }),
            });
        }

        protected override void AddOpcodes()
        {
            throw new NotImplementedException();
        }
    }
}
