using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class Add
    {
        public IList<Opcode> Opcodes { get; set; }

        public Add()
        {
            Opcodes = new List<Opcode>()
            {
                new Opcode("ADD A,(HL)", 0x86, null, OpcodeParameter.None, (z80) => 
                {
                    var hl = z80.Memory.Get(z80.HL.Value);
                    var a = z80.A.Value;
                    var result = hl + a;

                    z80.A.Value = (byte)result;

                    z80.F.SetZero(z80.A.Value);
                    z80.F.SetSubtraction(false);
                }),
                
                new Opcode("ADD A,(IX+o)", 0xDD, 0x86, OpcodeParameter.EightBitOffset, (z80) =>
                {
                    var ix = z80.Memory.Get(z80.IX.Value);



                }),
                /*
                new Opcode("ADD A,(IY+o)", 0xDD, 0x86, OpcodeParameter.EightBitOffset),
                new Opcode("ADD A,n", 0xC6, OpcodeParameter.EightBitValue),
                new Opcode("ADD A,r", 0x80, OpcodeParameter.Register),
                new Opcode("ADD A,IXp", 0xDD, 0x80, OpcodeParameter.High)
                */


            };
            
        }
    }
}
