using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [FlagsCalculation(OperationType.AddWithCarry,
        Sign = Affect.DefaultCalculation,
        Zero = Affect.DefaultCalculation,
        HalfCarry = Affect.DefaultCalculation,
        ParityOrOverflow = Affect.DefaultCalculation,
        Subtraction = Affect.Reset,
        Carry = Affect.DefaultCalculation)]
    public class ADC : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("ADC A, A", 0x8F, z80 => { z80.A.AddWithCarry(z80.A.Value, z80.F.Carry); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADC A, B", 0x88, z80 => { z80.A.AddWithCarry(z80.B.Value, z80.F.Carry); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADC A, C", 0x89, z80 => { z80.A.AddWithCarry(z80.C.Value, z80.F.Carry); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADC A, D", 0x8A, z80 => { z80.A.AddWithCarry(z80.D.Value, z80.F.Carry); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADC A, E", 0x8B, z80 => { z80.A.AddWithCarry(z80.E.Value, z80.F.Carry); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADC A, H", 0x8C, z80 => { z80.A.AddWithCarry(z80.H.Value, z80.F.Carry); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADC A, L", 0x8D, z80 => { z80.A.AddWithCarry(z80.L.Value, z80.F.Carry); return Execution.Result(TStates.Count(4), z80.A); }),

                new Instruction("ADC A, n",    0xCE, EncodingByte.Variable, z80 => { z80.A.AddWithCarry(z80.Buffer.Immediate, z80.F.Carry); return Execution.Result(TStates.Count(7), z80.A); }),
                new Instruction("ADC A, (HL)", 0x8E,                        z80 => { z80.A.AddWithCarry(z80.Memory.Get(z80.HL), z80.F.Carry); return Execution.Result(TStates.Count(7), z80.A); }),

                new Instruction("ADC A, (IX + d)", 0xDD, 0x8E, EncodingByte.Variable, z80 => {
                    z80.A.AddWithCarry(z80.Memory.Get(z80.IX, z80.Buffer.Displacement), z80.F.Carry);
                    return Execution.Result(TStates.Count(19), z80.A);
                }),

                new Instruction("ADC A, (IY + d)", 0xFD, 0x8E, EncodingByte.Variable, z80 => {
                    z80.A.AddWithCarry(z80.Memory.Get(z80.IY, z80.Buffer.Displacement), z80.F.Carry);
                    return Execution.Result(TStates.Count(19), z80.A);
                }),
            });
        }
    }
}
