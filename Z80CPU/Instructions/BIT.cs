using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Name.Zero, Affect.CalculatedInOpcode)]
    [Flag(Name.Subraction, Affect.Zero)]
    [Flag(Name.HalfCarry, Affect.One)]
    [Flag(Name.Sign, Affect.Undefined)]
    [Flag(Name.ParityOrOverflow, Affect.Undefined)]
    public class BIT : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("BIT 0, (HL)", 0xCB, 0x46, (z80) => { z80.F.Zero = z80.Memory.Get(z80.HL.Value).GetBit(0).IsZero(); return TStates.Count(12); }),
                new Opcode("BIT 1, (HL)", 0xCB, 0x4E, (z80) => { z80.F.Zero = z80.Memory.Get(z80.HL.Value).GetBit(1).IsZero(); return TStates.Count(12); }),
                new Opcode("BIT 2, (HL)", 0xCB, 0x56, (z80) => { z80.F.Zero = z80.Memory.Get(z80.HL.Value).GetBit(2).IsZero(); return TStates.Count(12); }),
                new Opcode("BIT 3, (HL)", 0xCB, 0x5E, (z80) => { z80.F.Zero = z80.Memory.Get(z80.HL.Value).GetBit(3).IsZero(); return TStates.Count(12); }),
                new Opcode("BIT 4, (HL)", 0xCB, 0x66, (z80) => { z80.F.Zero = z80.Memory.Get(z80.HL.Value).GetBit(4).IsZero(); return TStates.Count(12); }),
                new Opcode("BIT 5, (HL)", 0xCB, 0x6E, (z80) => { z80.F.Zero = z80.Memory.Get(z80.HL.Value).GetBit(5).IsZero(); return TStates.Count(12); }),
                new Opcode("BIT 6, (HL)", 0xCB, 0x76, (z80) => { z80.F.Zero = z80.Memory.Get(z80.HL.Value).GetBit(6).IsZero(); return TStates.Count(12); }),
                new Opcode("BIT 7, (HL)", 0xCB, 0x7E, (z80) => { z80.F.Zero = z80.Memory.Get(z80.HL.Value).GetBit(7).IsZero(); return TStates.Count(12); }),

                
                new Opcode("BIT 0, (IX + d)", 0xDD, 0xCB, Oprand.Any, 0x46, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IX.Value + z80.Buffer[2])).GetBit(0).IsZero(); return TStates.Count(20); }), 
                new Opcode("BIT 1, (IX + d)", 0xDD, 0xCB, Oprand.Any, 0x4E, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IX.Value + z80.Buffer[2])).GetBit(1).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 2, (IX + d)", 0xDD, 0xCB, Oprand.Any, 0x56, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IX.Value + z80.Buffer[2])).GetBit(2).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 3, (IX + d)", 0xDD, 0xCB, Oprand.Any, 0x5E, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IX.Value + z80.Buffer[2])).GetBit(3).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 4, (IX + d)", 0xDD, 0xCB, Oprand.Any, 0x66, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IX.Value + z80.Buffer[2])).GetBit(4).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 5, (IX + d)", 0xDD, 0xCB, Oprand.Any, 0x6E, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IX.Value + z80.Buffer[2])).GetBit(5).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 6, (IX + d)", 0xDD, 0xCB, Oprand.Any, 0x76, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IX.Value + z80.Buffer[2])).GetBit(6).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 7, (IX + d)", 0xDD, 0xCB, Oprand.Any, 0x7E, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IX.Value + z80.Buffer[2])).GetBit(7).IsZero(); return TStates.Count(20); }),

                new Opcode("BIT 0, (IY + d)", 0xFD, 0xCB, Oprand.Any, 0x46, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IY.Value + z80.Buffer[2])).GetBit(0).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 1, (IY + d)", 0xFD, 0xCB, Oprand.Any, 0x4E, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IY.Value + z80.Buffer[2])).GetBit(1).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 2, (IY + d)", 0xFD, 0xCB, Oprand.Any, 0x56, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IY.Value + z80.Buffer[2])).GetBit(2).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 3, (IY + d)", 0xFD, 0xCB, Oprand.Any, 0x5E, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IY.Value + z80.Buffer[2])).GetBit(3).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 4, (IY + d)", 0xFD, 0xCB, Oprand.Any, 0x66, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IY.Value + z80.Buffer[2])).GetBit(4).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 5, (IY + d)", 0xFD, 0xCB, Oprand.Any, 0x6E, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IY.Value + z80.Buffer[2])).GetBit(5).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 6, (IY + d)", 0xFD, 0xCB, Oprand.Any, 0x76, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IY.Value + z80.Buffer[2])).GetBit(6).IsZero(); return TStates.Count(20); }),
                new Opcode("BIT 7, (IY + d)", 0xFD, 0xCB, Oprand.Any, 0x7E, (z80) => { z80.F.Zero = z80.Memory.Get((ushort)(z80.IY.Value + z80.Buffer[2])).GetBit(7).IsZero(); return TStates.Count(20); }),
                
                new Opcode("BIT 0, A", 0x47, (z80) => { z80.F.Zero = z80.A.Value.GetBit(0).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 0, B", 0x40, (z80) => { z80.F.Zero = z80.B.Value.GetBit(0).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 0, C", 0x41, (z80) => { z80.F.Zero = z80.C.Value.GetBit(0).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 0, D", 0x42, (z80) => { z80.F.Zero = z80.D.Value.GetBit(0).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 0, E", 0x43, (z80) => { z80.F.Zero = z80.E.Value.GetBit(0).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 0, H", 0x47, (z80) => { z80.F.Zero = z80.H.Value.GetBit(0).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 0, L", 0x45, (z80) => { z80.F.Zero = z80.L.Value.GetBit(0).IsZero(); return TStates.Count(8); }),

                new Opcode("BIT 1, A", 0x4F, (z80) => { z80.F.Zero = z80.A.Value.GetBit(1).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 1, B", 0x48, (z80) => { z80.F.Zero = z80.B.Value.GetBit(1).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 1, C", 0x49, (z80) => { z80.F.Zero = z80.C.Value.GetBit(1).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 1, D", 0x4A, (z80) => { z80.F.Zero = z80.D.Value.GetBit(1).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 1, E", 0x4B, (z80) => { z80.F.Zero = z80.E.Value.GetBit(1).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 1, H", 0x4C, (z80) => { z80.F.Zero = z80.H.Value.GetBit(1).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 1, L", 0x4D, (z80) => { z80.F.Zero = z80.L.Value.GetBit(1).IsZero(); return TStates.Count(8); }),

                new Opcode("BIT 2, A", 0x57, (z80) => { z80.F.Zero = z80.A.Value.GetBit(2).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 2, B", 0x50, (z80) => { z80.F.Zero = z80.B.Value.GetBit(2).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 2, C", 0x51, (z80) => { z80.F.Zero = z80.C.Value.GetBit(2).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 2, D", 0x52, (z80) => { z80.F.Zero = z80.D.Value.GetBit(2).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 2, E", 0x53, (z80) => { z80.F.Zero = z80.E.Value.GetBit(2).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 2, H", 0x54, (z80) => { z80.F.Zero = z80.H.Value.GetBit(2).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 2, L", 0x55, (z80) => { z80.F.Zero = z80.L.Value.GetBit(2).IsZero(); return TStates.Count(8); }),

                new Opcode("BIT 3, A", 0x5F, (z80) => { z80.F.Zero = z80.A.Value.GetBit(3).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 3, B", 0x58, (z80) => { z80.F.Zero = z80.B.Value.GetBit(3).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 3, C", 0x59, (z80) => { z80.F.Zero = z80.C.Value.GetBit(3).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 3, D", 0x5A, (z80) => { z80.F.Zero = z80.D.Value.GetBit(3).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 3, E", 0x5B, (z80) => { z80.F.Zero = z80.E.Value.GetBit(3).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 3, H", 0x5C, (z80) => { z80.F.Zero = z80.H.Value.GetBit(3).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 3, L", 0x5D, (z80) => { z80.F.Zero = z80.L.Value.GetBit(3).IsZero(); return TStates.Count(8); }),

                new Opcode("BIT 4, A", 0x67, (z80) => { z80.F.Zero = z80.A.Value.GetBit(4).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 4, B", 0x60, (z80) => { z80.F.Zero = z80.B.Value.GetBit(4).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 4, C", 0x61, (z80) => { z80.F.Zero = z80.C.Value.GetBit(4).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 4, D", 0x62, (z80) => { z80.F.Zero = z80.D.Value.GetBit(4).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 4, E", 0x63, (z80) => { z80.F.Zero = z80.E.Value.GetBit(4).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 4, H", 0x64, (z80) => { z80.F.Zero = z80.H.Value.GetBit(4).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 4, L", 0x65, (z80) => { z80.F.Zero = z80.L.Value.GetBit(4).IsZero(); return TStates.Count(8); }),

                new Opcode("BIT 5, A", 0x6F, (z80) => { z80.F.Zero = z80.A.Value.GetBit(5).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 5, B", 0x68, (z80) => { z80.F.Zero = z80.B.Value.GetBit(5).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 5, C", 0x69, (z80) => { z80.F.Zero = z80.C.Value.GetBit(5).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 5, D", 0x6A, (z80) => { z80.F.Zero = z80.D.Value.GetBit(5).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 5, E", 0x6B, (z80) => { z80.F.Zero = z80.E.Value.GetBit(5).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 5, H", 0x6C, (z80) => { z80.F.Zero = z80.H.Value.GetBit(5).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 5, L", 0x6D, (z80) => { z80.F.Zero = z80.L.Value.GetBit(5).IsZero(); return TStates.Count(8); }),

                new Opcode("BIT 6, A", 0x77, (z80) => { z80.F.Zero = z80.A.Value.GetBit(6).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 6, B", 0x70, (z80) => { z80.F.Zero = z80.B.Value.GetBit(6).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 6, C", 0x71, (z80) => { z80.F.Zero = z80.C.Value.GetBit(6).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 6, D", 0x72, (z80) => { z80.F.Zero = z80.D.Value.GetBit(6).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 6, E", 0x73, (z80) => { z80.F.Zero = z80.E.Value.GetBit(6).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 6, H", 0x74, (z80) => { z80.F.Zero = z80.H.Value.GetBit(6).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 6, L", 0x75, (z80) => { z80.F.Zero = z80.L.Value.GetBit(6).IsZero(); return TStates.Count(8); }),

                new Opcode("BIT 7, A", 0x7F, (z80) => { z80.F.Zero = z80.A.Value.GetBit(7).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 7, B", 0x78, (z80) => { z80.F.Zero = z80.B.Value.GetBit(7).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 7, C", 0x79, (z80) => { z80.F.Zero = z80.C.Value.GetBit(7).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 7, D", 0x7A, (z80) => { z80.F.Zero = z80.D.Value.GetBit(7).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 7, E", 0x7B, (z80) => { z80.F.Zero = z80.E.Value.GetBit(7).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 7, H", 0x7C, (z80) => { z80.F.Zero = z80.H.Value.GetBit(7).IsZero(); return TStates.Count(8); }),
                new Opcode("BIT 7, L", 0x7D, (z80) => { z80.F.Zero = z80.L.Value.GetBit(7).IsZero(); return TStates.Count(8); }),
            });
        }
    }
}
