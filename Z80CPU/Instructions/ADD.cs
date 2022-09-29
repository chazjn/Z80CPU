using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Name.Sign, Affect.DefaultCalculation)]
    [Flag(Name.Zero, Affect.DefaultCalculation)]
    [Flag(Name.HalfCarry, Affect.DefaultCalculation)]
    [Flag(Name.ParityOrOverflow, Affect.DefaultCalculation)]
    [Flag(Name.Subraction, Affect.Reset)]
    [Flag(Name.Carry, Affect.DefaultCalculation)]
    public class ADD : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("ADD A, (HL)", 0x86, (z80) => {
                    var value = z80.Memory.Get(z80.HL);
                    z80.A.Add(value);
                    return TStates.Count(7);
                }),

                new Opcode("ADD A, (IX + d)", 0xDD, 0x86, Oprand.Any, (z80) =>
                {
                    var offset = z80.Buffer[2];
                    var ix_offset = z80.IX.Value + offset;
                    var value = z80.Memory.Get((ushort)ix_offset);
                    z80.A.Add(value);
                    return TStates.Count(17);
                }),

                new Opcode("ADD A, (IY + d)", 0xFD, 0x86, Oprand.Any, (z80) =>
                {
                    var offset = z80.Buffer[2];
                    var iy_offset = z80.IY.Value + offset;
                    var value = z80.Memory.Get((ushort)iy_offset);
                    z80.A.Add(value);
                    return TStates.Count(17);
                }),

                new Opcode("ADD A, n", 0xC6, Oprand.Any, (z80) => { z80.A.Add(z80.Buffer[1]); return TStates.Count(7); }),
                new Opcode("ADD A, A", 0x87, (z80) => { z80.A.Add(z80.A.Value); return TStates.Count(4); }),
                new Opcode("ADD A, B", 0x80, (z80) => { z80.A.Add(z80.B.Value); return TStates.Count(4); }),
                new Opcode("ADD A, C", 0x81, (z80) => { z80.A.Add(z80.C.Value); return TStates.Count(4); }),
                new Opcode("ADD A, D", 0x82, (z80) => { z80.A.Add(z80.D.Value); return TStates.Count(4); }),
                new Opcode("ADD A, E", 0x83, (z80) => { z80.A.Add(z80.E.Value); return TStates.Count(4); }),
                new Opcode("ADD A, H", 0x84, (z80) => { z80.A.Add(z80.H.Value); return TStates.Count(4); }),
                new Opcode("ADD A, L", 0x85, (z80) => { z80.A.Add(z80.L.Value); return TStates.Count(4); }),

                /*
                new Opcode("ADD HL, BC", 0x09, (z80) => { AddToRegister(z80, z80.HL, z80.BC.Value); }),
                new Opcode("ADD HL, DE", 0x19, (z80) => { AddToRegister(z80, z80.HL, z80.DE.Value); }),
                new Opcode("ADD HL, HL", 0x29, (z80) => { AddToRegister(z80, z80.HL, z80.HL.Value); }),
                new Opcode("ADD HL, SP", 0x39, (z80) => { AddToRegister(z80, z80.HL, z80.SP.Value); }),

                new Opcode("ADD IX, BC", 0xDD, 0x09, (z80) => { AddToRegister(z80, z80.IX, z80.BC.Value); }),
                new Opcode("ADD IX, DE", 0xDD, 0x19, (z80) => { AddToRegister(z80, z80.IX, z80.DE.Value); }),
                new Opcode("ADD IX, IX", 0xDD, 0x29, (z80) => { AddToRegister(z80, z80.IX, z80.IX.Value); }),
                new Opcode("ADD IX, SP", 0xDD, 0x39, (z80) => { AddToRegister(z80, z80.IX, z80.SP.Value); }),

                new Opcode("ADD IY, BC", 0xFD, 0x09, (z80) => { AddToRegister(z80, z80.IY, z80.BC.Value); }),
                new Opcode("ADD IY, DE", 0xFD, 0x19, (z80) => { AddToRegister(z80, z80.IY, z80.DE.Value); }),
                new Opcode("ADD IY, IY", 0xFD, 0x29, (z80) => { AddToRegister(z80, z80.IY, z80.IY.Value); }),
                new Opcode("ADD IY, SP", 0xFD, 0x39, (z80) => { AddToRegister(z80, z80.IY, z80.SP.Value); })
                */
            });                
        }
    }
}
