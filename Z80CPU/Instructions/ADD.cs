using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class ADD
    {
        public IList<Opcode> Opcodes { get; }

        public ADD()
        {
            Opcodes = new List<Opcode>()
            {
                new Opcode("ADD A,(HL)", 0x86),
                new Opcode("ADD A,(IX+o)", 0xDD, 0x86, OpcodeParameter.EightBitOffset),
                new Opcode("ADD A,(IY+o)", 0xDD, 0x86, OpcodeParameter.EightBitOffset),
                new Opcode("ADD A,n", 0xC6, OpcodeParameter.EightBitValue),
                new Opcode("ADD A,r", 0x80, OpcodeParameter.Register),
                new Opcode("ADD A,IXp", 0xDD, 0x80, OpcodeParameter.High)


            };
            
        }
    }
}
