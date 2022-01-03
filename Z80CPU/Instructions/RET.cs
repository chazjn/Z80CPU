using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class RET : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("RET",    0xC9, z80 => { Ret(z80, true); return TStates.Count(10); }),
                new Opcode("RET NZ", 0xC0, z80 => { return Ret(z80, !z80.F.Zero); }),
                new Opcode("RET Z",  0xC8, z80 => { return Ret(z80, z80.F.Zero); }),
                new Opcode("RET NC", 0xD0, z80 => { return Ret(z80, !z80.F.Carry); }),
                new Opcode("RET C",  0xD8, z80 => { return Ret(z80, z80.F.Carry); }),
                new Opcode("RET PO", 0xE0, z80 => { return Ret(z80, !z80.F.ParityOrOverflow); }),
                new Opcode("RET PE", 0xE8, z80 => { return Ret(z80, z80.F.ParityOrOverflow); }),
                new Opcode("RET P",  0xF0, z80 => { return Ret(z80, !z80.F.Sign); }),
                new Opcode("RET M",  0xF8, z80 => { return Ret(z80, z80.F.Sign); }),
            });
        }

        private TStates Ret(Z80 z80, bool invokeReturn)
        {
            if(invokeReturn)
            {
                z80.PC.Low.Value = z80.Memory.Get(z80.SP.Value);
                z80.PC.High.Value = z80.Memory.Get(z80.SP.Value + 1);

                z80.SP.Increment();
                z80.SP.Increment();

                return TStates.Count(11);
            }

            return TStates.Count(5);
        }
    }
}
