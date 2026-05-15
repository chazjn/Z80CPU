using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class OR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("OR A", 0xB7, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("OR B", 0xB0, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("OR C", 0xB1, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("OR D", 0xB2, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("OR E", 0xB3, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("OR H", 0xB4, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("OR L", 0xB5, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("OR (HL)", 0xB6, z80 => { /* TODO */ return Execution.Result(TStates.Count(7)); }),
                new Instruction("OR n", 0xF6, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(7)); }),
                new Instruction("OR (IX + d)", 0xDD, 0xB6, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(19)); }),
                new Instruction("OR (IY + d)", 0xFD, 0xB6, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(19)); }),
            });
        }
    }
}
