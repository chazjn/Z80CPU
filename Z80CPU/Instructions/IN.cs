using System;
using System.Collections.Generic;
using System.Text;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    public class IN : Instruction
    {
        public IN()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("IN A, (C)", 0xED, 0x78, (z80) => { SetRegister(z80, z80.A); }),
                new Opcode("IN B, (C)", 0xED, 0x40, (z80) => { SetRegister(z80, z80.B); }),
                new Opcode("IN C, (C)", 0xED, 0x48, (z80) => { SetRegister(z80, z80.C); }),
                new Opcode("IN D, (C)", 0xED, 0x50, (z80) => { SetRegister(z80, z80.D); }),
                new Opcode("IN E, (C)", 0xED, 0x58, (z80) => { SetRegister(z80, z80.E); }),
                new Opcode("IN H, (C)", 0xED, 0x60, (z80) => { SetRegister(z80, z80.H); }),
                new Opcode("IN L, (C)", 0xED, 0x68, (z80) => { SetRegister(z80, z80.L); }),


            });
        }

        public void SetRegister(Z80 z80, Register8 destination)
        {
            var address = ByteHelper.CreateUShort(z80.C.Value, z80.B.Value);

            var value = z80.Ports.GetByte(address);
            //TODO: set flags
            destination.Value = value;
        }

        protected override void AddOpcodes()
        {
            throw new NotImplementedException();
        }
    }
}
