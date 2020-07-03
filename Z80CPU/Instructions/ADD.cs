using System.Collections.Generic;
using System.Linq;

namespace Z80CPU.Instructions
{
    public class ADD
    {
        public IList<Opcode> Opcodes { get; }

        public ADD()
        {
            Opcodes = new List<Opcode>()
            {
                new Opcode("ADD A,(HL)", new byte[]{ 0x86 }, (z80) => 
                {
                    var hl = z80.Memory.Get(z80.HL.Value);
                    var a = z80.A.Value;
                    var result = hl + a;

                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),
                
                new Opcode("ADD A,(IX+o)", new byte[]{ 0xDD, 0x86 }, (z80) =>
                {
                    var offset = z80.Buffer[2];
                    var ix_offset = z80.IX.Value + offset;
                    var ix_offset_value = z80.Memory.Get((ushort)ix_offset);
                    var a = z80.A.Value;
                    var result = a + ix_offset_value;

                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),
                
                new Opcode("ADD A,(IY+o)", new[]{ new ByteValue(0xFD), new ByteValue(0x86), ByteValue.Any }, (z80) =>
                {
                    var offset = z80.Buffer[2];
                    var iy_offset = z80.IY.Value + offset;
                    var iy_offset_value = z80.Memory.Get((ushort)iy_offset);
                    var a = z80.A.Value;
                    var result = a + iy_offset_value;

                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),
                
                new Opcode("ADD A,n", new ByteValue[]{ new ByteValue(0xC6), ByteValue.Any }, (z80) =>
                {
                    var result = z80.A.Value + z80.Buffer[1];
                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),

                new Opcode("ADD A,A", new byte[]{ 0x87 }, (z80) =>
                {
                    var result = z80.A.Value + z80.A.Value;
                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),

                new Opcode("ADD A,B", new byte[]{ 0x80 }, (z80) =>
                {
                    var result = z80.A.Value + z80.B.Value;
                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),

                new Opcode("ADD A,C", new byte[] { 0x81 }, (z80) =>
                {
                    var result = z80.A.Value + z80.C.Value;
                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),

                new Opcode("ADD A,D", new byte[]{ 0x82 }, (z80) =>
                {
                    var result = z80.A.Value + z80.D.Value;
                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),

                new Opcode("ADD A,E", new byte[]{ 0x83 }, (z80) =>
                {
                    var result = z80.A.Value + z80.E.Value;
                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),

                new Opcode("ADD A,H", new byte[]{ 0x84 }, (z80) =>
                {
                    var result = z80.A.Value + z80.H.Value;
                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),

                new Opcode("ADD A,L", new byte[]{ 0x85 }, (z80) =>
                {
                    var result = z80.A.Value + z80.L.Value;
                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),   
                
                new Opcode("ADD A,IX low", new[]{ new ByteValue(0xDD), new ByteValue(0x85) }, (z80) =>
                {

                }),

                new Opcode("ADD A,IX high", new[]{ new ByteValue(0xDD), new ByteValue(0x84) }, (z80) =>
                {

                })
            };
        }
    }
}
