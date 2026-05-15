using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class DEC : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("DEC A", 0x3D, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("DEC B", 0x05, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("DEC C", 0x0D, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("DEC D", 0x15, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("DEC E", 0x1D, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("DEC H", 0x25, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("DEC L", 0x2D, z80 => { /* TODO */ return Execution.Result(TStates.Count(4)); }),
                new Instruction("DEC (HL)", 0x35, z80 => { /* TODO */ return Execution.Result(TStates.Count(11)); }),
                new Instruction("DEC (IX + d)", 0xDD, 0x35, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
                new Instruction("DEC (IY + d)", 0xFD, 0x35, EncodingByte.Variable, z80 => { /* TODO */ return Execution.Result(TStates.Count(23)); }),
            });
        }
    }
}
