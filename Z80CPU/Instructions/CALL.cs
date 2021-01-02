using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class CALL : Instruction
    {
        public CALL()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("CALL NZ, pq", 0xC4, (z80) => { Call(z80, z80.F.Zero == false); }),
                new Opcode("CALL Z, pq", 0xCC, (z80) => { Call(z80, z80.F.Zero == true); }),
                new Opcode("CALL NC, pq", 0xD4, (z80) => { Call(z80, z80.F.Carry == false); }),
                new Opcode("CALL C, pq", 0xE4, (z80) => { Call(z80, z80.F.Carry == true); }),
                new Opcode("CALL PO, pq", 0xE4, (z80) => { Call(z80, z80.F.ParityOrOverflow == false); }),
                new Opcode("CALL PE, pq", 0xEC, (z80) => { Call(z80, z80.F.ParityOrOverflow == true); }),
                new Opcode("CALL P, pq", 0xF4, (z80) => { Call(z80, z80.F.Sign == false); }),
                new Opcode("CALL M, pq", 0xFC, (z80) => { Call(z80, z80.F.Sign == true); }),

                new Opcode("CALL pq", 0xCD, (z80) => { Call(z80, true); }),
            });
        }

        public void Call(Z80 z80, bool call)
        {
            //jump over pq bytes
            z80.PC.Increment();
            z80.PC.Increment();

            if (call == true)
            {
                z80.SP.Decrement();
                z80.Memory.Set(z80.SP.Value, z80.PC.High.Value);
                z80.SP.Decrement();
                z80.Memory.Set(z80.SP.Value, z80.PC.Low.Value);

                z80.PC.Low.Value = z80.Memory.Get(z80.PC.Value - 1);
                z80.PC.High.Value = z80.Memory.Get(z80.PC.Value - 2);
            }
        }
    }
}
