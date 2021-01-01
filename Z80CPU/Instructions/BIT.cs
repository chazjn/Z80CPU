using System;
using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class BIT : Instruction
    {
        public BIT()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("BIT 0, (HL)", 0xCB, 0x46, (z80) => { TestBit(z80, z80.Memory.Get(z80.HL.Value), 0); }),
                new Opcode("BIT 1, (HL)", 0xCB, 0x4E, (z80) => { TestBit(z80, z80.Memory.Get(z80.HL.Value), 1); }),
                new Opcode("BIT 2, (HL)", 0xCB, 0x56, (z80) => { TestBit(z80, z80.Memory.Get(z80.HL.Value), 2); }),
                new Opcode("BIT 3, (HL)", 0xCB, 0x5E, (z80) => { TestBit(z80, z80.Memory.Get(z80.HL.Value), 3); }),
                new Opcode("BIT 4, (HL)", 0xCB, 0x66, (z80) => { TestBit(z80, z80.Memory.Get(z80.HL.Value), 4); }),
                new Opcode("BIT 5, (HL)", 0xCB, 0x6E, (z80) => { TestBit(z80, z80.Memory.Get(z80.HL.Value), 5); }),
                new Opcode("BIT 6, (HL)", 0xCB, 0x76, (z80) => { TestBit(z80, z80.Memory.Get(z80.HL.Value), 6); }),
                new Opcode("BIT 7, (HL)", 0xCB, 0x7E, (z80) => { TestBit(z80, z80.Memory.Get(z80.HL.Value), 7); }),

                new Opcode("BIT 0, (IX + d)", new[] { new Oprand(0xDD), new Oprand(0xCB), Oprand.Any, new Oprand(0x46) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IX.Value + z80.Buffer[2]), 0); }),
                new Opcode("BIT 1, (IX + d)", new[] { new Oprand(0xDD), new Oprand(0xCB), Oprand.Any, new Oprand(0x4E) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IX.Value + z80.Buffer[2]), 1); }),
                new Opcode("BIT 2, (IX + d)", new[] { new Oprand(0xDD), new Oprand(0xCB), Oprand.Any, new Oprand(0x56) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IX.Value + z80.Buffer[2]), 2); }),
                new Opcode("BIT 3, (IX + d)", new[] { new Oprand(0xDD), new Oprand(0xCB), Oprand.Any, new Oprand(0x5E) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IX.Value + z80.Buffer[2]), 3); }),
                new Opcode("BIT 4, (IX + d)", new[] { new Oprand(0xDD), new Oprand(0xCB), Oprand.Any, new Oprand(0x66) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IX.Value + z80.Buffer[2]), 4); }),
                new Opcode("BIT 5, (IX + d)", new[] { new Oprand(0xDD), new Oprand(0xCB), Oprand.Any, new Oprand(0x6E) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IX.Value + z80.Buffer[2]), 5); }),
                new Opcode("BIT 6, (IX + d)", new[] { new Oprand(0xDD), new Oprand(0xCB), Oprand.Any, new Oprand(0x76) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IX.Value + z80.Buffer[2]), 6); }),
                new Opcode("BIT 7, (IX + d)", new[] { new Oprand(0xDD), new Oprand(0xCB), Oprand.Any, new Oprand(0x7E) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IX.Value + z80.Buffer[2]), 7); }),

                new Opcode("BIT 0, (IY + d)", new[] { new Oprand(0xFD), new Oprand(0xCB), Oprand.Any, new Oprand(0x46) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IY.Value + z80.Buffer[2]), 0); }),
                new Opcode("BIT 1, (IY + d)", new[] { new Oprand(0xFD), new Oprand(0xCB), Oprand.Any, new Oprand(0x4E) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IY.Value + z80.Buffer[2]), 1); }),
                new Opcode("BIT 2, (IY + d)", new[] { new Oprand(0xFD), new Oprand(0xCB), Oprand.Any, new Oprand(0x56) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IY.Value + z80.Buffer[2]), 2); }),
                new Opcode("BIT 3, (IY + d)", new[] { new Oprand(0xFD), new Oprand(0xCB), Oprand.Any, new Oprand(0x5E) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IY.Value + z80.Buffer[2]), 3); }),
                new Opcode("BIT 4, (IY + d)", new[] { new Oprand(0xFD), new Oprand(0xCB), Oprand.Any, new Oprand(0x66) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IY.Value + z80.Buffer[2]), 4); }),
                new Opcode("BIT 5, (IY + d)", new[] { new Oprand(0xFD), new Oprand(0xCB), Oprand.Any, new Oprand(0x6E) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IY.Value + z80.Buffer[2]), 5); }),
                new Opcode("BIT 6, (IY + d)", new[] { new Oprand(0xFD), new Oprand(0xCB), Oprand.Any, new Oprand(0x76) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IY.Value + z80.Buffer[2]), 6); }),
                new Opcode("BIT 7, (IY + d)", new[] { new Oprand(0xFD), new Oprand(0xCB), Oprand.Any, new Oprand(0x7E) }, (z80) => { TestBit(z80, z80.Memory.Get(z80.IY.Value + z80.Buffer[2]), 7); }),

                new Opcode("BIT 0, A", 0x47, (z80) => { TestBit(z80, z80.A.Value, 0); }),
                new Opcode("BIT 0, B", 0x40, (z80) => { TestBit(z80, z80.B.Value, 0); }),
                new Opcode("BIT 0, C", 0x41, (z80) => { TestBit(z80, z80.C.Value, 0); }),
                new Opcode("BIT 0, D", 0x42, (z80) => { TestBit(z80, z80.D.Value, 0); }),
                new Opcode("BIT 0, E", 0x43, (z80) => { TestBit(z80, z80.E.Value, 0); }),
                new Opcode("BIT 0, H", 0x47, (z80) => { TestBit(z80, z80.H.Value, 0); }),
                new Opcode("BIT 0, L", 0x45, (z80) => { TestBit(z80, z80.L.Value, 0); }),

                new Opcode("BIT 1, A", 0x4F, (z80) => { TestBit(z80, z80.A.Value, 1); }),
                new Opcode("BIT 1, B", 0x48, (z80) => { TestBit(z80, z80.B.Value, 1); }),
                new Opcode("BIT 1, C", 0x49, (z80) => { TestBit(z80, z80.C.Value, 1); }),
                new Opcode("BIT 1, D", 0x4A, (z80) => { TestBit(z80, z80.D.Value, 1); }),
                new Opcode("BIT 1, E", 0x4B, (z80) => { TestBit(z80, z80.E.Value, 1); }),
                new Opcode("BIT 1, H", 0x4C, (z80) => { TestBit(z80, z80.H.Value, 1); }),
                new Opcode("BIT 1, L", 0x4D, (z80) => { TestBit(z80, z80.L.Value, 1); }),

                new Opcode("BIT 2, A", 0x57, (z80) => { TestBit(z80, z80.A.Value, 2); }),
                new Opcode("BIT 2, B", 0x50, (z80) => { TestBit(z80, z80.B.Value, 2); }),
                new Opcode("BIT 2, C", 0x51, (z80) => { TestBit(z80, z80.C.Value, 2); }),
                new Opcode("BIT 2, D", 0x52, (z80) => { TestBit(z80, z80.D.Value, 2); }),
                new Opcode("BIT 2, E", 0x53, (z80) => { TestBit(z80, z80.E.Value, 2); }),
                new Opcode("BIT 2, H", 0x54, (z80) => { TestBit(z80, z80.H.Value, 2); }),
                new Opcode("BIT 2, L", 0x55, (z80) => { TestBit(z80, z80.L.Value, 2); }),

                new Opcode("BIT 3, A", 0x5F, (z80) => { TestBit(z80, z80.A.Value, 3); }),
                new Opcode("BIT 3, B", 0x58, (z80) => { TestBit(z80, z80.B.Value, 3); }),
                new Opcode("BIT 3, C", 0x59, (z80) => { TestBit(z80, z80.C.Value, 3); }),
                new Opcode("BIT 3, D", 0x5A, (z80) => { TestBit(z80, z80.D.Value, 3); }),
                new Opcode("BIT 3, E", 0x5B, (z80) => { TestBit(z80, z80.E.Value, 3); }),
                new Opcode("BIT 3, H", 0x5C, (z80) => { TestBit(z80, z80.H.Value, 3); }),
                new Opcode("BIT 3, L", 0x5D, (z80) => { TestBit(z80, z80.L.Value, 3); }),

                new Opcode("BIT 4, A", 0x67, (z80) => { TestBit(z80, z80.A.Value, 4); }),
                new Opcode("BIT 4, B", 0x60, (z80) => { TestBit(z80, z80.B.Value, 4); }),
                new Opcode("BIT 4, C", 0x61, (z80) => { TestBit(z80, z80.C.Value, 4); }),
                new Opcode("BIT 4, D", 0x62, (z80) => { TestBit(z80, z80.D.Value, 4); }),
                new Opcode("BIT 4, E", 0x63, (z80) => { TestBit(z80, z80.E.Value, 4); }),
                new Opcode("BIT 4, H", 0x64, (z80) => { TestBit(z80, z80.H.Value, 4); }),
                new Opcode("BIT 4, L", 0x65, (z80) => { TestBit(z80, z80.L.Value, 4); }),

                new Opcode("BIT 5, A", 0x6F, (z80) => { TestBit(z80, z80.A.Value, 5); }),
                new Opcode("BIT 5, B", 0x68, (z80) => { TestBit(z80, z80.B.Value, 5); }),
                new Opcode("BIT 5, C", 0x69, (z80) => { TestBit(z80, z80.C.Value, 5); }),
                new Opcode("BIT 5, D", 0x6A, (z80) => { TestBit(z80, z80.D.Value, 5); }),
                new Opcode("BIT 5, E", 0x6B, (z80) => { TestBit(z80, z80.E.Value, 5); }),
                new Opcode("BIT 5, H", 0x6C, (z80) => { TestBit(z80, z80.H.Value, 5); }),
                new Opcode("BIT 5, L", 0x6D, (z80) => { TestBit(z80, z80.L.Value, 5); }),

                new Opcode("BIT 6, A", 0x77, (z80) => { TestBit(z80, z80.A.Value, 6); }),
                new Opcode("BIT 6, B", 0x70, (z80) => { TestBit(z80, z80.B.Value, 6); }),
                new Opcode("BIT 6, C", 0x71, (z80) => { TestBit(z80, z80.C.Value, 6); }),
                new Opcode("BIT 6, D", 0x72, (z80) => { TestBit(z80, z80.D.Value, 6); }),
                new Opcode("BIT 6, E", 0x73, (z80) => { TestBit(z80, z80.E.Value, 6); }),
                new Opcode("BIT 6, H", 0x74, (z80) => { TestBit(z80, z80.H.Value, 6); }),
                new Opcode("BIT 6, L", 0x75, (z80) => { TestBit(z80, z80.L.Value, 6); }),

                new Opcode("BIT 7, A", 0x7F, (z80) => { TestBit(z80, z80.A.Value, 7); }),
                new Opcode("BIT 7, B", 0x78, (z80) => { TestBit(z80, z80.B.Value, 7); }),
                new Opcode("BIT 7, C", 0x79, (z80) => { TestBit(z80, z80.C.Value, 7); }),
                new Opcode("BIT 7, D", 0x7A, (z80) => { TestBit(z80, z80.D.Value, 7); }),
                new Opcode("BIT 7, E", 0x7B, (z80) => { TestBit(z80, z80.E.Value, 7); }),
                new Opcode("BIT 7, H", 0x7C, (z80) => { TestBit(z80, z80.H.Value, 7); }),
                new Opcode("BIT 7, L", 0x7D, (z80) => { TestBit(z80, z80.L.Value, 7); }),
            });
        }

        private void TestBit(Z80 z80, byte value, int position)
        {
            var bit = value.GetBit(position);
            
            if (bit == 1)
            {
                z80.F.Zero = false;
            }
            else
            {
                z80.F.Zero = true;
            }

            var random = new Random();
            z80.F.Sign = (random.Next(2) == 0);
            z80.F.HalfCarry = true;
            z80.F.ParityOrOverflow = (random.Next(2) == 0);
            z80.F.Subtraction = false;
        }
    }
}
