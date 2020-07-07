using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class ADD
    {
        public IList<Opcode> Opcodes { get; }

        public ADD()
        {
            Opcodes = new List<Opcode>
            {
                new Opcode("ADD A, (HL)", 0x86, (z80) => 
                {
                    var hl = z80.Memory.Get(z80.HL.Value);
                    var a = z80.A.Value;
                    var result = (byte)(hl + a);

                    SetFlags(z80, z80.A.Value, hl, result);
                    z80.A.Value = result;
                }),
                
                new Opcode("ADD A, (IX + d)", new[]{ new Oprand(0xDD), new Oprand(0x86), Oprand.Any }, (z80) =>
                {
                    var offset = z80.Buffer[2];
                    var ix_offset = z80.IX.Value + offset;
                    var ix_offset_value = z80.Memory.Get(ix_offset);
                    var a = z80.A.Value;
                    var result = (byte)(a + ix_offset_value);

                    SetFlags(z80, z80.A.Value, ix_offset_value, result);
                    z80.A.Value = result;
                }),
                
                new Opcode("ADD A, (IY + d)", new[]{ new Oprand(0xFD), new Oprand(0x86), Oprand.Any }, (z80) =>
                {
                    var offset = z80.Buffer[2];
                    var iy_offset = z80.IY.Value + offset;
                    var iy_offset_value = z80.Memory.Get(iy_offset);
                    var a = z80.A.Value;
                    var result = (byte)(a + iy_offset_value);

                    SetFlags(z80, z80.A.Value, iy_offset_value, result);
                    z80.A.Value = result;
                }),
                
                new Opcode("ADD A,  n", new[]{ new Oprand(0xC6), Oprand.Any }, (z80) =>
                {
                    var result = (byte)(z80.A.Value + z80.Buffer[1]);

                    SetFlags(z80, z80.A.Value, z80.Buffer[1], result);
                    z80.A.Value = result;

                }),

                new Opcode("ADD A, A", 0x87, (z80) =>
                {
                    var result = (byte)(z80.A.Value + z80.A.Value);

                    SetFlags(z80, z80.A.Value, z80.A.Value, result);
                    z80.A.Value = result;
                    
                }),

                new Opcode("ADD A, B", 0x80, (z80) =>
                {
                    var result = (byte)(z80.A.Value + z80.B.Value);

                    SetFlags(z80, z80.A.Value, z80.B.Value, result);
                    z80.A.Value = result;
                }),

                new Opcode("ADD A, C", 0x81, (z80) =>
                {
                    var result = (byte)(z80.A.Value + z80.C.Value);

                    SetFlags(z80, z80.A.Value, z80.C.Value, result);
                    z80.A.Value = result;
                }),

                new Opcode("ADD A, D", 0x82, (z80) =>
                {
                    var result = (byte)(z80.A.Value + z80.D.Value);

                    SetFlags(z80, z80.A.Value, z80.D.Value, result);
                    z80.A.Value = result;
                }),

                new Opcode("ADD A, E", 0x83, (z80) =>
                {
                    var result = (byte)(z80.A.Value + z80.E.Value);

                    SetFlags(z80, z80.A.Value, z80.E.Value, result);
                    z80.A.Value = result;
                }),

                new Opcode("ADD A, H", 0x84, (z80) =>
                {
                    var result = (byte)(z80.A.Value + z80.H.Value);

                    SetFlags(z80, z80.A.Value, z80.H.Value, result);
                    z80.A.Value = result;
                }),

                new Opcode("ADD A, L", 0x85, (z80) =>
                {
                    var result = (byte)(z80.A.Value + z80.L.Value);

                    SetFlags(z80, z80.A.Value, z80.L.Value, result);
                    z80.A.Value = result;
                }),
                
                new Opcode("ADD HL, BC", 0x09, (z80) => 
                {
                    var result = (ushort)(z80.HL.Value + z80.BC.Value);

                    SetFlags(z80, z80.HL.Value, z80.BC.Value, result);
                    z80.HL.Value = result;
                }),

                new Opcode("ADD HL, DE", 0x19, (z80) => 
                {
                    var result = (ushort)(z80.HL.Value + z80.DE.Value);

                    SetFlags(z80, z80.HL.Value, z80.DE.Value, result);
                    z80.HL.Value = result;
                }),

                new Opcode("ADD HL, HL", 0x29, (z80) => 
                {
                    var result = (ushort)(z80.HL.Value + z80.HL.Value);

                    SetFlags(z80, z80.HL.Value, z80.HL.Value, result);
                    z80.HL.Value = result;
                }),

                new Opcode("ADD HL, SP", 0x39, (z80) => 
                { 
                    var result = (ushort)(z80.HL.Value + z80.SP.Value);

                    SetFlags(z80, z80.HL.Value, z80.SP.Value, result);
                    z80.HL.Value = result;
                }),

                new Opcode("ADD IX, BC", 0xDD, 0x09, (z80) => 
                { 
                    var result = (ushort)(z80.IX.Value + z80.BC.Value);

                    SetFlags(z80, z80.IX.Value, z80.BC.Value, result);
                    z80.IX.Value = result;
                }),

                new Opcode("ADD IX, DE", 0xDD, 0x19, (z80) => 
                {
                    var result = (ushort)(z80.IX.Value + z80.DE.Value);

                    SetFlags(z80, z80.IX.Value, z80.DE.Value, result);
                    z80.IX.Value = result;
                }),
               
                new Opcode("ADD IX, IX", 0xDD, 0x29, (z80) => 
                {
                    var result = (ushort)(z80.IX.Value + z80.IX.Value);

                    SetFlags(z80, z80.IX.Value, z80.IX.Value, result);
                    z80.IX.Value = result;
                }),

                new Opcode("ADD IX, SP", 0xDD, 0x39, (z80) => 
                {
                    var result = (ushort)(z80.IX.Value + z80.SP.Value);

                    SetFlags(z80, z80.IX.Value, z80.SP.Value, result);
                    z80.IX.Value = result;
                }),

                new Opcode("ADD IY, BC", 0xFD, 0x9, (z80) => 
                {
                    var result = (ushort)(z80.IY.Value + z80.BC.Value);

                    SetFlags(z80, z80.IY.Value, z80.BC.Value, result);
                    z80.IX.Value = result;
                }),

                new Opcode("ADD IY, DE", 0xFD, 0x19, (z80) => 
                {
                    var result = (ushort)(z80.IY.Value + z80.DE.Value);

                    SetFlags(z80, z80.IY.Value, z80.DE.Value, result);
                    z80.IY.Value = result;
                }),

                new Opcode("ADD IY, IY", 0xFD, 0x29, (z80) => 
                {
                   var result = (ushort)(z80.IY.Value + z80.IY.Value);

                    SetFlags(z80, z80.IY.Value, z80.IY.Value, result);
                    z80.IY.Value = result;
                }),

                new Opcode("ADD IY, SP", 0xFD, 0x39, (z80) => 
                {
                    var result = (ushort)(z80.IY.Value + z80.SP.Value);

                    SetFlags(z80, z80.IY.Value, z80.SP.Value, result);
                    z80.IY.Value = result;
                }),
            };
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
