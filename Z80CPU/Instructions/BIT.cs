﻿using System;
using System.Collections.Generic;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    public class BIT : Instruction
    {
        public BIT()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("BIT 0, A", 0x47, (z80) => { TestBit(z80, z80.A, 0); }),
                new Opcode("BIT 0, B", 0x40, (z80) => { TestBit(z80, z80.B, 0); }),
                new Opcode("BIT 0, C", 0x41, (z80) => { TestBit(z80, z80.C, 0); }),
                new Opcode("BIT 0, D", 0x42, (z80) => { TestBit(z80, z80.D, 0); }),
                new Opcode("BIT 0, E", 0x43, (z80) => { TestBit(z80, z80.E, 0); }),
                new Opcode("BIT 0, H", 0x47, (z80) => { TestBit(z80, z80.H, 0); }),
                new Opcode("BIT 0, L", 0x45, (z80) => { TestBit(z80, z80.L, 0); }),

                new Opcode("BIT 1, A", 0x4F, (z80) => { TestBit(z80, z80.A, 1); }),
                new Opcode("BIT 1, B", 0x48, (z80) => { TestBit(z80, z80.B, 1); }),
                new Opcode("BIT 1, C", 0x49, (z80) => { TestBit(z80, z80.C, 1); }),
                new Opcode("BIT 1, D", 0x4A, (z80) => { TestBit(z80, z80.D, 1); }),
                new Opcode("BIT 1, E", 0x4B, (z80) => { TestBit(z80, z80.E, 1); }),
                new Opcode("BIT 1, H", 0x4C, (z80) => { TestBit(z80, z80.H, 1); }),
                new Opcode("BIT 1, L", 0x4D, (z80) => { TestBit(z80, z80.L, 1); }),

                new Opcode("BIT 2, A", 0x57, (z80) => { TestBit(z80, z80.A, 2); }),
                new Opcode("BIT 2, B", 0x50, (z80) => { TestBit(z80, z80.B, 2); }),
                new Opcode("BIT 2, C", 0x51, (z80) => { TestBit(z80, z80.C, 2); }),
                new Opcode("BIT 2, D", 0x52, (z80) => { TestBit(z80, z80.D, 2); }),
                new Opcode("BIT 2, E", 0x53, (z80) => { TestBit(z80, z80.E, 2); }),
                new Opcode("BIT 2, H", 0x54, (z80) => { TestBit(z80, z80.H, 2); }),
                new Opcode("BIT 2, L", 0x55, (z80) => { TestBit(z80, z80.L, 2); }),

                new Opcode("BIT 3, A", 0x5F, (z80) => { TestBit(z80, z80.A, 3); }),
                new Opcode("BIT 3, B", 0x58, (z80) => { TestBit(z80, z80.B, 3); }),
                new Opcode("BIT 3, C", 0x59, (z80) => { TestBit(z80, z80.C, 3); }),
                new Opcode("BIT 3, D", 0x5A, (z80) => { TestBit(z80, z80.D, 3); }),
                new Opcode("BIT 3, E", 0x5B, (z80) => { TestBit(z80, z80.E, 3); }),
                new Opcode("BIT 3, H", 0x5C, (z80) => { TestBit(z80, z80.H, 3); }),
                new Opcode("BIT 3, L", 0x5D, (z80) => { TestBit(z80, z80.L, 3); }),

                new Opcode("BIT 4, A", 0x67, (z80) => { TestBit(z80, z80.A, 4); }),
                new Opcode("BIT 4, B", 0x60, (z80) => { TestBit(z80, z80.B, 4); }),
                new Opcode("BIT 4, C", 0x61, (z80) => { TestBit(z80, z80.C, 4); }),
                new Opcode("BIT 4, D", 0x62, (z80) => { TestBit(z80, z80.D, 4); }),
                new Opcode("BIT 4, E", 0x63, (z80) => { TestBit(z80, z80.E, 4); }),
                new Opcode("BIT 4, H", 0x64, (z80) => { TestBit(z80, z80.H, 4); }),
                new Opcode("BIT 4, L", 0x65, (z80) => { TestBit(z80, z80.L, 4); }),

                new Opcode("BIT 5, A", 0x6F, (z80) => { TestBit(z80, z80.A, 5); }),
                new Opcode("BIT 5, B", 0x68, (z80) => { TestBit(z80, z80.B, 5); }),
                new Opcode("BIT 5, C", 0x69, (z80) => { TestBit(z80, z80.C, 5); }),
                new Opcode("BIT 5, D", 0x6A, (z80) => { TestBit(z80, z80.D, 5); }),
                new Opcode("BIT 5, E", 0x6B, (z80) => { TestBit(z80, z80.E, 5); }),
                new Opcode("BIT 5, H", 0x6C, (z80) => { TestBit(z80, z80.H, 5); }),
                new Opcode("BIT 5, L", 0x6D, (z80) => { TestBit(z80, z80.L, 5); }),

                new Opcode("BIT 6, A", 0x77, (z80) => { TestBit(z80, z80.A, 6); }),
                new Opcode("BIT 6, B", 0x70, (z80) => { TestBit(z80, z80.B, 6); }),
                new Opcode("BIT 6, C", 0x71, (z80) => { TestBit(z80, z80.C, 6); }),
                new Opcode("BIT 6, D", 0x72, (z80) => { TestBit(z80, z80.D, 6); }),
                new Opcode("BIT 6, E", 0x73, (z80) => { TestBit(z80, z80.E, 6); }),
                new Opcode("BIT 6, H", 0x74, (z80) => { TestBit(z80, z80.H, 6); }),
                new Opcode("BIT 6, L", 0x75, (z80) => { TestBit(z80, z80.L, 6); }),

                new Opcode("BIT 7, A", 0x7F, (z80) => { TestBit(z80, z80.A, 7); }),
                new Opcode("BIT 7, B", 0x78, (z80) => { TestBit(z80, z80.B, 7); }),
                new Opcode("BIT 7, C", 0x79, (z80) => { TestBit(z80, z80.C, 7); }),
                new Opcode("BIT 7, D", 0x7A, (z80) => { TestBit(z80, z80.D, 7); }),
                new Opcode("BIT 7, E", 0x7B, (z80) => { TestBit(z80, z80.E, 7); }),
                new Opcode("BIT 7, H", 0x7C, (z80) => { TestBit(z80, z80.H, 7); }),
                new Opcode("BIT 7, L", 0x7D, (z80) => { TestBit(z80, z80.L, 7); }),
            });
        }

        private void TestBit(Z80 z80, Register8 register, int position)
        {
            var value = register.Value.GetBit(position);

            if(value == 1)
            {
                z80.F.Zero = false;
            }

            var random = new Random();
            z80.F.Sign = (random.Next(2) == 0);
            z80.F.HalfCarry = true;
            z80.F.ParityOrOverflow = (random.Next(2) == 0);
            z80.F.Subtraction = false;
        }
    }
}
