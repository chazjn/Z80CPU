using System.Collections.Generic;
using Z80CPU.Flags;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    public class LD : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("LD BC, (nn)", 0xED, 0x4B, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return LoadFromMemoryIntoRegister(z80, z80.BC); }),
                new Instruction("LD DE, (nn)", 0xED, 0x5B, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return LoadFromMemoryIntoRegister(z80, z80.DE); }),
                new Instruction("LD HL, (nn)", 0xED, 0x6B, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return LoadFromMemoryIntoRegister(z80, z80.HL); }),
                new Instruction("LD SP, (nn)", 0xED, 0x7B, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return LoadFromMemoryIntoRegister(z80, z80.SP); }),

                new Instruction("LD A, n", 0x3E, EncodingByte.Variable, (z80) => { z80.A.Value = z80.Buffer.Immediate; return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD B, n", 0x06, EncodingByte.Variable, (z80) => { z80.B.Value = z80.Buffer.Immediate; return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD C, n", 0x0E, EncodingByte.Variable, (z80) => { z80.C.Value = z80.Buffer.Immediate; return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD D, n", 0x16, EncodingByte.Variable, (z80) => { z80.D.Value = z80.Buffer.Immediate; return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD E, n", 0x1E, EncodingByte.Variable, (z80) => { z80.E.Value = z80.Buffer.Immediate; return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD H, n", 0x26, EncodingByte.Variable, (z80) => { z80.H.Value = z80.Buffer.Immediate; return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD L, n", 0x2E, EncodingByte.Variable, (z80) => { z80.L.Value = z80.Buffer.Immediate; return Execution.Result(TStates.Count(7)); }),

                new Instruction("LD BC, nn", 0x01, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return LoadIntoRegister(z80, z80.BC); }),
                new Instruction("LD DE, nn", 0x11, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return LoadIntoRegister(z80, z80.DE); }),
                new Instruction("LD HL, nn", 0x21, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return LoadIntoRegister(z80, z80.HL); }),
                new Instruction("LD SP, nn", 0x31, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return LoadIntoRegister(z80, z80.SP); }),

                //page 295

                new Instruction("LD (BC), A", 0x02, (z80) =>
                {
                    z80.Memory.Set(z80.BC.Value, z80.A.Value);
                    return Execution.Result(TStates.Count(7));
                }),

                new Instruction("LD (DE), A", 0x12, (z80) =>
                {
                    z80.Memory.Set(z80.DE.Value, z80.A.Value);
                    return Execution.Result(TStates.Count(7));
                }),

                new Instruction("LD (HL), n", 0x36, EncodingByte.Variable, (z80) =>
                {
                    z80.Memory.Set(z80.HL.Value, z80.Buffer.Immediate);
                    return Execution.Result(TStates.Count(10));
                }),

                new Instruction("LD (HL), A", 0x77, (z80) => { z80.Memory.Set(z80.HL, z80.A.Value); return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD (HL), B", 0x70, (z80) => { z80.Memory.Set(z80.HL, z80.B.Value); return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD (HL), C", 0x71, (z80) => { z80.Memory.Set(z80.HL, z80.C.Value); return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD (HL), D", 0x72, (z80) => { z80.Memory.Set(z80.HL, z80.D.Value); return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD (HL), E", 0x73, (z80) => { z80.Memory.Set(z80.HL, z80.E.Value); return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD (HL), H", 0x74, (z80) => { z80.Memory.Set(z80.HL, z80.H.Value); return Execution.Result(TStates.Count(7)); }),
                new Instruction("LD (HL), L", 0x75, (z80) => { z80.Memory.Set(z80.HL, z80.L.Value); return Execution.Result(TStates.Count(7)); })
            });
        }

        private Execution LoadFromMemoryIntoRegister(Z80 z80, Register16 register)
        {
            var address = ByteHelper.CreateUShort(z80.Buffer[3], z80.Buffer[2]);
            var low = z80.Memory.Get(address);
            var high = z80.Memory.Get(++address);
            register.Value = ByteHelper.CreateUShort(high, low);
            return Execution.Result(TStates.Count(20));
        }

        private Execution LoadIntoRegister(Z80 z80, Register16 register)
        {
            register.Value = ByteHelper.CreateUShort(z80.Buffer[2], z80.Buffer.Immediate);
            return Execution.Result(TStates.Count(10));
        }
    }
}
