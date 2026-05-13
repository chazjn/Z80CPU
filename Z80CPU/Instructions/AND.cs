using System.Collections.Generic;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    [OperationType(OperationType.Logic)]
    [Flag(Name.Sign, Affect.DefaultCalculation)]
    [Flag(Name.Zero, Affect.DefaultCalculation)]
    [Flag(Name.HalfCarry, Affect.Set)]
    [Flag(Name.ParityOrOverflow, Affect.DefaultCalculation)]
    [Flag(Name.Subraction, Affect.Reset)]
    [Flag(Name.Carry, Affect.Reset)]
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
                    z80.A.Value &= z80.Buffer[1];
                    return Execution.Result(TStates.Count(7), z80.A);
                }),

                new Instruction("AND (HL)", 0xA6, (z80) =>
                {
                    z80.A.Value &= z80.Memory.Get(z80.HL);
                    return Execution.Result(TStates.Count(7), z80.A);
                }),

                new Instruction("AND (IX + d)", 0xDD, 0xA6, EncodingByte.Variable, (z80) =>
                {
                    z80.A.Value &= z80.Memory.Get((ushort)(z80.IX.Value + z80.Buffer[2]));
                    return Execution.Result(TStates.Count(19), z80.A);
                }),

                new Instruction("AND (IY + d)", 0xFD, 0xA6, EncodingByte.Variable, (z80) =>
                {
                    z80.A.Value &= z80.Memory.Get((ushort)(z80.IY.Value + z80.Buffer[2]));
                    return Execution.Result(TStates.Count(19), z80.A);
                })
            });
        }
    }
}
