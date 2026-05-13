using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [FlagsCalculation(OperationType.Add,
        Sign = Affect.DefaultCalculation,
        Zero = Affect.DefaultCalculation,
        HalfCarry = Affect.DefaultCalculation,
        ParityOrOverflow = Affect.DefaultCalculation,
        Subtraction = Affect.Reset)]
    public class INC : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("INC A", 0x3C, (z80) => { z80.A.Increment(); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("INC B", 0x04, (z80) => { z80.B.Increment(); return Execution.Result(TStates.Count(4), z80.B); }),
                new Instruction("INC C", 0x0C, (z80) => { z80.C.Increment(); return Execution.Result(TStates.Count(4), z80.C); }),
                new Instruction("INC D", 0x14, (z80) => { z80.D.Increment(); return Execution.Result(TStates.Count(4), z80.D); }),
                new Instruction("INC E", 0x1C, (z80) => { z80.E.Increment(); return Execution.Result(TStates.Count(4), z80.E); }),
                new Instruction("INC H", 0x24, (z80) => { z80.H.Increment(); return Execution.Result(TStates.Count(4), z80.H); }),
                new Instruction("INC L", 0x2C, (z80) => { z80.L.Increment(); return Execution.Result(TStates.Count(4), z80.L); }),
            });
        }
    }
}
