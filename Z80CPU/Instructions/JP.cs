using System;
using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class JP : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("JP NZ, pq", 0xC2, Oprand.Any, Oprand.Any, (z80) => { Jump(z80, !z80.F.Zero); return TStates.Count(10); }),
                new Opcode("JP Z, pq",  0xCA, Oprand.Any, Oprand.Any, (z80) => { Jump(z80, z80.F.Zero); return TStates.Count(10); }),
                new Opcode("JP NC, pq", 0xD2, Oprand.Any, Oprand.Any, (z80) => { Jump(z80, !z80.F.Carry); return TStates.Count(10); }),
                new Opcode("JP C, pq",  0xDA, Oprand.Any, Oprand.Any, (z80) => { Jump(z80, z80.F.Carry); return TStates.Count(10); }),
                new Opcode("JP PO, pq", 0xE2, Oprand.Any, Oprand.Any, (z80) => { Jump(z80, !z80.F.ParityOrOverflow); return TStates.Count(10); }),
                new Opcode("JP PE, pq", 0xEA, Oprand.Any, Oprand.Any, (z80) => { Jump(z80, z80.F.ParityOrOverflow); return TStates.Count(10); }),
                new Opcode("JP P, pq",  0xF2, Oprand.Any, Oprand.Any, (z80) => { Jump(z80, !z80.F.Sign); return TStates.Count(10); }),
                new Opcode("JP M, pq",  0xFA, Oprand.Any, Oprand.Any, (z80) => { Jump(z80, z80.F.Sign); return TStates.Count(10); }),
                new Opcode("JP pq",     0xC3, Oprand.Any, Oprand.Any, (z80) => { Jump(z80, true); return TStates.Count(10); }),
                new Opcode("JP (HL)",   0xE9, (z80) => { z80.PC.Value = z80.HL.Value; return TStates.Count(4); }),
                new Opcode("JP (IX)",   0xDD, 0xE9, (z80) => { z80.PC.Value = z80.IX.Value; return TStates.Count(8); }),
                new Opcode("JP (IY)",   0xFD, 0xE9, (z80) => { z80.PC.Value = z80.IY.Value; return TStates.Count(8); })
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
