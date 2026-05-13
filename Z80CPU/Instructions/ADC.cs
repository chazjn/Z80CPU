using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class ADC : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("ADC A, A", 0x8F, z80 =>
                {
                    return Execution.Result(TStates.Count(4));
                }),

                new Instruction("ADC A, B", 0x88, z80 =>
                {
                    return Execution.Result(TStates.Count(4));
                }),

                new Instruction("ADC A, C", 0x89, z80 =>
                {
                    return Execution.Result(TStates.Count(4));
                }),

                new Instruction("ADC A, D", 0x8A, z80 =>
                {
                    return Execution.Result(TStates.Count(4));
                }),

                new Instruction("ADC A, E", 0x8B, z80 =>
                {
                    return Execution.Result(TStates.Count(4));
                }),

                new Instruction("ADC A, H", 0x8C, z80 =>
                {
                    return Execution.Result(TStates.Count(4));
                }),

                new Instruction("ADC A, L", 0x8D, z80 =>
                {
                    return Execution.Result(TStates.Count(4));
                }),

                new Instruction("ADC A, n", 0xCE, EncodingByte.Variable, z80 =>
                {
                    return Execution.Result(TStates.Count(7));
                }),

                new Instruction("ADC A, (HL)", 0x8E, z80 =>
                {
                    return Execution.Result(TStates.Count(7));
                }),

                new Instruction("ADC A, (IX + d)", 0xDD, 0x8E, EncodingByte.Variable, z80 =>
                {
                    return Execution.Result(TStates.Count(19));
                }),

                new Instruction("ADC A, (IY + d)", 0xFD, 0x8E, EncodingByte.Variable, z80 =>
                {
                    return Execution.Result(TStates.Count(19));
                }),
            });
        }
    }
}
