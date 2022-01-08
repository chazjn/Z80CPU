using System;
using System.Collections.Generic;
using System.Text;
using Z80CPU.Flags;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    [Flag(Affect.CalculatedInOpcode)]
    public class LD : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("LD BC, (nn)", 0xED, 0x4B, Oprand.Any, Oprand.Any, (z80) => { return LoadIntoRegister(z80, z80.BC); }),
                new Opcode("LD DE, (nn)", 0xED, 0x5B, Oprand.Any, Oprand.Any, (z80) => { return LoadIntoRegister(z80, z80.DE); }),
                new Opcode("LD HL, (nn)", 0xED, 0x6B, Oprand.Any, Oprand.Any, (z80) => { return LoadIntoRegister(z80, z80.HL); }),
                new Opcode("LD SP, (nn)", 0xED, 0x7B, Oprand.Any, Oprand.Any, (z80) => { return LoadIntoRegister(z80, z80.SP); }),

                new Opcode("LD A, n", 0x3E, Oprand.Any, (z80) => { z80.A.Value = z80.Buffer[1]; return TStates.Count(7); }),
                new Opcode("LD B, n", 0x06, Oprand.Any, (z80) => { z80.B.Value = z80.Buffer[1]; return TStates.Count(7); }),
                new Opcode("LD C, n", 0x0E, Oprand.Any, (z80) => { z80.C.Value = z80.Buffer[1]; return TStates.Count(7); }),
                new Opcode("LD D, n", 0x16, Oprand.Any, (z80) => { z80.D.Value = z80.Buffer[1]; return TStates.Count(7); }),
                new Opcode("LD E, n", 0x1E, Oprand.Any, (z80) => { z80.E.Value = z80.Buffer[1]; return TStates.Count(7); }),
                new Opcode("LD H, n", 0x26, Oprand.Any, (z80) => { z80.H.Value = z80.Buffer[1]; return TStates.Count(7); }),
                new Opcode("LD L, n", 0x2E, Oprand.Any, (z80) => { z80.L.Value = z80.Buffer[1]; return TStates.Count(7); }),


                new Opcode("LD (BC), A", 0x02, (z80) =>
                {
                    var bc = z80.BC.Value;
                    var a = z80.A.Value;
                    z80.Memory.Set(bc, a);
                }),

                new Opcode("LD (DE), A", 0x12, (z80) =>
                {
                    var de = z80.DE.Value;
                    var a = z80.A.Value;
                    z80.Memory.Set(de, a);
                }),

                new Opcode("LD (HL), n", 0x36, Oprand.Any, (z80) =>
                {
                    var hl = z80.HL.Value;
                    var value = z80.Buffer[1];
                    z80.Memory.Set(hl, value);
                }),

                new Opcode("LD (HL), B", 0x70, (z80) =>
                {
                    var hl = z80.HL.Value;
                    var value = z80.Memory.Get(hl);
                    z80.BC.Value = value;
                })
            });

        }

        private TStates LoadIntoRegister(Z80 z80, Register16 register)
        {
            var address = ByteHelper.CreateUShort(z80.Buffer[3], z80.Buffer[2]);
            var low = z80.Memory.Get(address);
            var high = z80.Memory.Get(++address);
            register.Value = ByteHelper.CreateUShort(high, low);
            return TStates.Count(20);
        }
    }
}
