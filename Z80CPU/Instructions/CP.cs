using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class CP : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("CP A", 0xBF, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("CP B", 0xB8, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("CP C", 0xB9, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("CP D", 0xBA, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("CP E", 0xBB, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("CP H", 0xBC, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("CP L", 0xBD, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("CP (HL)", 0xBE, z80 => { /* TODO */ return Execution.Result(TStates.Count(7)); }),
                new Instruction("CP n", 0xFE, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(7)); }),
                new Instruction("CP (IX + d)", 0xDD, 0xBE, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(19)); }),
                new Instruction("CP (IY + d)", 0xFD, 0xBE, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(19)); }),
            });
        }
    }
}
