using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [FlagsCalculation(OperationType.Logic,
        Sign = Affect.DefaultCalculation,
        Zero = Affect.DefaultCalculation,
        HalfCarry = Affect.Set,
        ParityOrOverflow = Affect.DefaultCalculation,
        Subtraction = Affect.Reset,
        Carry = Affect.Reset)]
    public class AND : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("AND A", 0xA7, (z80) => { z80.A.Value &= z80.A.Value; return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("AND B", 0xA0, (z80) => { z80.A.Value &= z80.B.Value; return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("AND C", 0xA1, (z80) => { z80.A.Value &= z80.C.Value; return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("AND D", 0xA2, (z80) => { z80.A.Value &= z80.D.Value; return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("AND E", 0xA3, (z80) => { z80.A.Value &= z80.E.Value; return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("AND H", 0xA4, (z80) => { z80.A.Value &= z80.H.Value; return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("AND L", 0xA5, (z80) => { z80.A.Value &= z80.L.Value; return Execution.Result(TStates.Count(4), z80.A); }),

                new Instruction("AND n", 0xE6, EncodingByte.Variable, (z80) => {
                    z80.A.Value &= z80.Buffer.Immediate;
                    return Execution.Result(TStates.Count(7), z80.A);
                }),

                new Instruction("AND (HL)", 0xA6, (z80) =>
                {
                    z80.A.Value &= z80.Memory.Get(z80.HL);
                    return Execution.Result(TStates.Count(7), z80.A);
                }),

                new Instruction("AND (IX + d)", 0xDD, 0xA6, EncodingByte.Variable, (z80) =>
                {
                    z80.A.Value &= z80.Memory.Get(z80.IX, z80.Buffer.Displacement);
                    return Execution.Result(TStates.Count(19), z80.A);
                }),

                new Instruction("AND (IY + d)", 0xFD, 0xA6, EncodingByte.Variable, (z80) =>
                {
                    z80.A.Value &= z80.Memory.Get(z80.IY, z80.Buffer.Displacement);
                    return Execution.Result(TStates.Count(19), z80.A);
                })
            });
        }
    }
}
