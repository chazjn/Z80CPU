using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class RET : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("RET",    0xC9, z80 => { Ret(z80, true); return TStates.Count(10); }),
                new Instruction("RET NZ", 0xC0, z80 => { return Ret(z80, !z80.F.Zero); }),
                new Instruction("RET Z",  0xC8, z80 => { return Ret(z80, z80.F.Zero); }),
                new Instruction("RET NC", 0xD0, z80 => { return Ret(z80, !z80.F.Carry); }),
                new Instruction("RET C",  0xD8, z80 => { return Ret(z80, z80.F.Carry); }),
                new Instruction("RET PO", 0xE0, z80 => { return Ret(z80, !z80.F.ParityOrOverflow); }),
                new Instruction("RET PE", 0xE8, z80 => { return Ret(z80, z80.F.ParityOrOverflow); }),
                new Instruction("RET P",  0xF0, z80 => { return Ret(z80, !z80.F.Sign); }),
                new Instruction("RET M",  0xF8, z80 => { return Ret(z80, z80.F.Sign); }),
            });
        }

        private TStates Ret(Z80 z80, bool invokeReturn)
        {
            if(invokeReturn)
            {
                z80.PC.Low.Value = z80.Memory.Get(z80.SP);
                z80.PC.High.Value = z80.Memory.Get((ushort)(z80.SP.Value + 1));

                z80.SP.Increment();
                z80.SP.Increment();

                return TStates.Count(11);
            }

            return TStates.Count(5);
        }
    }
}
