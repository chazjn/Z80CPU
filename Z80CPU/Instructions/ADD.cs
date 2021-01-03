using System.Collections.Generic;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    public class ADD : Instruction
    {
        public ADD()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("ADD A, (HL)", 0x86, (z80) => 
                {
                    var value = z80.Memory.Get(z80.HL.Value);
                    AddToA(z80, value);
                }),
                
                new Opcode("ADD A, (IX + d)", 0xDD, 0x86, (z80) =>
                {
                    var offset = z80.GetByte();
                    var ix_offset = z80.IX.Value + offset;
                    var value = z80.Memory.Get(ix_offset);
                    AddToA(z80, value);
                }),
                
                new Opcode("ADD A, (IY + d)", 0xFD, 0x86, (z80) =>
                {
                    var offset = z80.GetByte();
                    var iy_offset = z80.IY.Value + offset;
                    var value = z80.Memory.Get(iy_offset);
                    AddToA(z80, value);
                }),
                
                new Opcode("ADD A, n", 0xC6, (z80) => 
                {
                    var value = z80.GetByte();
                    AddToA(z80, value); 
                }),

                new Opcode("ADD A, A", 0x87, (z80) => { AddToA(z80, z80.A.Value); }),
                new Opcode("ADD A, B", 0x80, (z80) => { AddToA(z80, z80.B.Value); }),    
                new Opcode("ADD A, C", 0x81, (z80) => { AddToA(z80, z80.C.Value); }),
                new Opcode("ADD A, D", 0x82, (z80) => { AddToA(z80, z80.D.Value); }),
                new Opcode("ADD A, E", 0x83, (z80) => { AddToA(z80, z80.E.Value); }),
                new Opcode("ADD A, H", 0x84, (z80) => { AddToA(z80, z80.H.Value); }),
                new Opcode("ADD A, L", 0x85, (z80) => { AddToA(z80, z80.L.Value); }),

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
            });
        }

        public void AddToA(Z80 z80, byte value)
        {
            var result = (byte)(z80.A.Value + value);
            z80.A.Value = result;
            SetFlags(z80, z80.A.Value, value, result);
        }

        public void AddToRegister(Z80 z80, Register16 destination, ushort value)
        {
            var result = (ushort)(destination.Value + value);
            destination.Value = result;
            SetFlags(z80, destination.Value, value, result);
        }

        private void SetFlags(Z80 z80, byte original, byte addition, byte result)
        {
            z80.F.Sign = (result >> 7) == 1;

            z80.F.Zero = result == 0;

            z80.F.HalfCarry = ((original ^ addition ^ result) & 0x10) == 1;

            z80.F.ParityOrOverflow = ((original ^ addition ^ 0x80) & (addition ^ result) & 0x80) == 1;

            z80.F.Subtraction = false;

            z80.F.Carry = original + addition > 255;
        }

        private void SetFlags(Z80 z80, ushort original, ushort addition, ushort result)
        {
            z80.F.HalfCarry = ((original ^ addition ^ result) & 0x1000) == 1;

            z80.F.Subtraction = false;

            z80.F.Carry = original + addition > 65535;
        }
    }
}
