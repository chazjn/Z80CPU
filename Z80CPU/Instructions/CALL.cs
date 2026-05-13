using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class CALL : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("CALL NZ, pq", 0xC4, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return Call(z80, !z80.F.Zero); }),
                new Instruction("CALL Z,  pq", 0xCC, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return Call(z80, z80.F.Zero); }),
                new Instruction("CALL NC, pq", 0xD4, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return Call(z80, !z80.F.Carry); }),
                new Instruction("CALL C,  pq", 0xDC, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return Call(z80, z80.F.Carry); }),
                new Instruction("CALL PO, pq", 0xE4, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return Call(z80, !z80.F.ParityOrOverflow); }),
                new Instruction("CALL PE, pq", 0xEC, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return Call(z80, z80.F.ParityOrOverflow); }),
                new Instruction("CALL P,  pq", 0xF4, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return Call(z80, !z80.F.Sign); }),
                new Instruction("CALL M,  pq", 0xFC, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return Call(z80, z80.F.Sign); }),

                new Instruction("CALL pq", 0xCD, EncodingByte.Variable, EncodingByte.Variable, (z80) => { return Call(z80, true); }),
            });
        }

        private Execution Call(Z80 z80, bool performCall)
        {
            if (!performCall)
                return Execution.Result(TStates.Count(10));

            z80.SP.Decrement();
            z80.Memory.Set(z80.SP.Value, z80.PC.High.Value);
            z80.SP.Decrement();
            z80.Memory.Set(z80.SP.Value, z80.PC.Low.Value);

            z80.PC.Low.Value = z80.Memory.Get((ushort)(z80.PC.Value - 1));
            z80.PC.High.Value = z80.Memory.Get((ushort)(z80.PC.Value - 2));

            return Execution.Result(TStates.Count(17));
        }
    }
}
