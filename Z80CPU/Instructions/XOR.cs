using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class XOR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("XOR A", 0xAF, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("XOR B", 0xA8, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("XOR C", 0xA9, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("XOR D", 0xAA, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("XOR E", 0xAB, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("XOR H", 0xAC, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("XOR L", 0xAD, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("XOR (HL)", 0xAE, z80 => { /* TODO */ return Execution.Result(TStates.Count(7)); }),
                new Instruction("XOR n", 0xEE, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(7)); }),
                new Instruction("XOR (IX + d)", 0xDD, 0xAE, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(19)); }),
                new Instruction("XOR (IY + d)", 0xFD, 0xAE, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(19)); }),
            });
        }
    }
}
