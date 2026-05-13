using System.Collections.Generic;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    [OperationType(OperationType.Add)]
    [Flag(Name.Sign, Affect.DefaultCalculation)]
    [Flag(Name.Zero, Affect.DefaultCalculation)]
    [Flag(Name.HalfCarry, Affect.DefaultCalculation)]
    [Flag(Name.ParityOrOverflow, Affect.DefaultCalculation)]
    [Flag(Name.Subraction, Affect.Reset)]
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
