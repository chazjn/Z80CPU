using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class CALL : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("CALL NZ, pq", 0xC4, (z80) => { return Call(z80, !z80.F.Zero); }),
                new Opcode("CALL Z,  pq", 0xCC, (z80) => { return Call(z80, z80.F.Zero); }),
                new Opcode("CALL NC, pq", 0xD4, (z80) => { return Call(z80, !z80.F.Carry); }),
                new Opcode("CALL C,  pq", 0xE4, (z80) => { return Call(z80, z80.F.Carry); }),
                new Opcode("CALL PO, pq", 0xE4, (z80) => { return Call(z80, !z80.F.ParityOrOverflow); }),
                new Opcode("CALL PE, pq", 0xEC, (z80) => { return Call(z80, z80.F.ParityOrOverflow); }),
                new Opcode("CALL P,  pq", 0xF4, (z80) => { return Call(z80, !z80.F.Sign); }),
                new Opcode("CALL M,  pq", 0xFC, (z80) => { return Call(z80, z80.F.Sign); }),

                new Opcode("CALL pq", 0xCD, (z80) => { return Call(z80, true); }),
            });
        }

        public TStates Call(Z80 z80, bool performCall)
        {
            //jump over pq bytes
            z80.PC.Increment();
            z80.PC.Increment();

            if (performCall)
            {
                z80.SP.Decrement();
                z80.Memory.Set(z80.SP.Value, z80.PC.High.Value);
                z80.SP.Decrement();
                z80.Memory.Set(z80.SP.Value, z80.PC.Low.Value);

                z80.PC.Low.Value = z80.Memory.Get(z80.PC.Value - 1);
                z80.PC.High.Value = z80.Memory.Get(z80.PC.Value - 2);

                return TStates.Count(17);
            }
            else
            {
                return TStates.Count(10);
            }
        }
    }
}
