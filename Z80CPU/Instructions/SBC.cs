using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class SBC : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("SBC A, A", 0x9F, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("SBC A, B", 0x98, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("SBC A, C", 0x99, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("SBC A, D", 0x9A, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("SBC A, E", 0x9B, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("SBC A, H", 0x9C, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("SBC A, L", 0x9D, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("SBC A, (HL)", 0x9E, z80 => { /* TODO */ return Execution.Result(TStates.Count(7)); }),
                new Instruction("SBC A, n", 0xDE, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(7)); }),
                new Instruction("SBC A, (IX + d)", 0xDD, 0x9E, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(19)); }),
                new Instruction("SBC A, (IY + d)", 0xFD, 0x9E, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(19)); }),

                new Instruction("SBC HL, BC", 0xED, 0x42, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SBC HL, DE", 0xED, 0x52, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SBC HL, HL", 0xED, 0x62, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
                new Instruction("SBC HL, SP", 0xED, 0x72, z80 => { /* TODO */ return Execution.Result(TStates.Count(15)); }),
            });
        }
    }
}
