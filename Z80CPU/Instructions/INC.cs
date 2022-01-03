using System.Collections.Generic;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    public class INC : Instruction
    {
        public INC()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("INC A", 0x3C, (z80) => { Increment(z80, z80.A); }),
                new Opcode("INC B", 0x04, (z80) => { Increment(z80, z80.B); }),
                new Opcode("INC C", 0x0C, (z80) => { Increment(z80, z80.C); }),
                new Opcode("INC D", 0x14, (z80) => { Increment(z80, z80.D); }),
                new Opcode("INC E", 0x1C, (z80) => { Increment(z80, z80.E); }),
                new Opcode("INC H", 0x24, (z80) => { Increment(z80, z80.H); }),
                new Opcode("INC L", 0x2C, (z80) => { Increment(z80, z80.L); }),

                new Opcode("INC BC", 0x03, (z80) => { z80.BC.Increment(); }),
                new Opcode("INC DE", 0x13, (z80) => { z80.DE.Increment(); }),
                new Opcode("INC HL", 0x23, (z80) => { z80.HL.Increment(); }),
                new Opcode("INC SP", 0x33, (z80) => { z80.SP.Increment(); }),

                new Opcode("INC (HL)", 0x34, (z80) => { Increment(z80, z80.HL.Value); }),
                
                new Opcode("INC (IX + d)", 0xDD, 0x34, (z80) => 
                {
                    var offset = z80.GetByte();
                    var memoryLocation = z80.IX.Value + offset;
                    Increment(z80, memoryLocation);
                }),

                new Opcode("INC (IY + d)", 0xFD, 0x34, (z80) => 
                {
                    var offset = z80.GetByte();
                    var memoryLocation = z80.IY.Value + offset;
                    Increment(z80, memoryLocation);
                }),

                new Opcode("INC IX", 0xDD, 0x23, (z80) => { z80.IX.Increment(); }),
                new Opcode("INC IY", 0xFD, 0x23, (z80) => { z80.IY.Increment(); }),
            });
        }

        public void Increment(Z80 z80, Register8 register)
        {
            var value = register.Value;
            var newValue = ++register.Value;
            
            //set flags
        }

        public void Increment(Z80 z80, int memoryLocation)
        {
            var value = z80.Memory.Get(memoryLocation);
            var newValue = ++value;
            z80.Memory.Set(memoryLocation, newValue);

            //set flags
        }

        protected override void AddOpcodes()
        {
            throw new System.NotImplementedException();
        }
    }
}
