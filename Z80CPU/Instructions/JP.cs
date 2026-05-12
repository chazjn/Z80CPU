using System;
using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class JP : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("JP NZ, pq", 0xC2, EncodingByte.Variable, EncodingByte.Variable, (z80) => { Jump(z80, !z80.F.Zero); return TStates.Count(10); }),
                new Instruction("JP Z, pq",  0xCA, EncodingByte.Variable, EncodingByte.Variable, (z80) => { Jump(z80, z80.F.Zero); return TStates.Count(10); }),
                new Instruction("JP NC, pq", 0xD2, EncodingByte.Variable, EncodingByte.Variable, (z80) => { Jump(z80, !z80.F.Carry); return TStates.Count(10); }),
                new Instruction("JP C, pq",  0xDA, EncodingByte.Variable, EncodingByte.Variable, (z80) => { Jump(z80, z80.F.Carry); return TStates.Count(10); }),
                new Instruction("JP PO, pq", 0xE2, EncodingByte.Variable, EncodingByte.Variable, (z80) => { Jump(z80, !z80.F.ParityOrOverflow); return TStates.Count(10); }),
                new Instruction("JP PE, pq", 0xEA, EncodingByte.Variable, EncodingByte.Variable, (z80) => { Jump(z80, z80.F.ParityOrOverflow); return TStates.Count(10); }),
                new Instruction("JP P, pq",  0xF2, EncodingByte.Variable, EncodingByte.Variable, (z80) => { Jump(z80, !z80.F.Sign); return TStates.Count(10); }),
                new Instruction("JP M, pq",  0xFA, EncodingByte.Variable, EncodingByte.Variable, (z80) => { Jump(z80, z80.F.Sign); return TStates.Count(10); }),
                new Instruction("JP pq",     0xC3, EncodingByte.Variable, EncodingByte.Variable, (z80) => { Jump(z80, true); return TStates.Count(10); }),
                new Instruction("JP (HL)",   0xE9, (z80) => { z80.PC.Value = z80.HL.Value; return TStates.Count(4); }),
                new Instruction("JP (IX)",   0xDD, 0xE9, (z80) => { z80.PC.Value = z80.IX.Value; return TStates.Count(8); }),
                new Instruction("JP (IY)",   0xFD, 0xE9, (z80) => { z80.PC.Value = z80.IY.Value; return TStates.Count(8); })
            });
        }

        private void Jump(Z80 z80, bool performJump)
        {
            if (performJump)
            {
                var address = BitConverter.ToUInt16(new[] { z80.Buffer[2], z80.Buffer[1] }, 0);
                z80.PC.Value = address;
            }
        }
    }
}
