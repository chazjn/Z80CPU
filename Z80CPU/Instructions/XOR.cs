using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [FlagsCalculation(OperationType.Logic,
        Sign = Affect.DefaultCalculation,
        Zero = Affect.DefaultCalculation,
        HalfCarry = Affect.Reset,
        ParityOrOverflow = Affect.DefaultCalculation,
        Subtraction = Affect.Reset,
        Carry = Affect.Reset
        )]
    public class XOR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("XOR A", 0xAF, z80 => { z80.A.Value = (byte)(z80.A.Value ^ z80.A.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("XOR B", 0xA8, z80 => { z80.A.Value = (byte)(z80.A.Value ^ z80.B.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("XOR C", 0xA9, z80 => { z80.A.Value = (byte)(z80.A.Value ^ z80.C.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("XOR D", 0xAA, z80 => { z80.A.Value = (byte)(z80.A.Value ^ z80.D.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("XOR E", 0xAB, z80 => { z80.A.Value = (byte)(z80.A.Value ^ z80.E.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("XOR H", 0xAC, z80 => { z80.A.Value = (byte)(z80.A.Value ^ z80.H.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("XOR L", 0xAD, z80 => { z80.A.Value = (byte)(z80.A.Value ^ z80.L.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                
                new Instruction("XOR (HL)", 0xAE, z80 => { z80.A.Value = (byte)(z80.A.Value ^ z80.Memory.Get(z80.HL.Value)); return Execution.Result(TStates.Count(7), z80.A); }),
                
                new Instruction("XOR n", 0xEE, EncodingByte.Variable, z80 => { z80.A.Value = (byte)(z80.A.Value ^ z80.Buffer.Immediate); return Execution.Result(TStates.Count(7), z80.A); }),
                
                new Instruction("XOR (IX + d)", 0xDD, 0xAE, EncodingByte.Variable, z80 => 
                {
                    z80.A.Value  = (byte)(z80.A.Value ^ z80.Memory.Get(z80.IX, z80.Buffer.Displacement));
                    return Execution.Result(TStates.Count(19), z80.A); 
                }),
               
                new Instruction("XOR (IY + d)", 0xFD, 0xAE, EncodingByte.Variable, z80 => 
                {
                    z80.A.Value  = (byte)(z80.A.Value ^ z80.Memory.Get(z80.IY, z80.Buffer.Displacement));
                    return Execution.Result(TStates.Count(19), z80.A); 
                }),
            });
        }
    }
}
