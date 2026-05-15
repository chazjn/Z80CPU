using System;
using System.Collections.Generic;
using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    public class POP : Mnemonic
    {
        //TODO: check low/high byte orders
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("POP BC", 0xC1, (z80) =>
                {
                    Pop(z80, z80.BC);
                    return Execution.Result(TStates.Count(10));
                }),

                new Instruction("POP DE", 0xD1, (z80) =>
                {
                    Pop(z80, z80.DE);
                    return Execution.Result(TStates.Count(10));
                }),

                new Instruction("POP HL", 0xE1, (z80) =>
                {
                    Pop(z80, z80.HL);
                    return Execution.Result(TStates.Count(10));
                }),

                new Instruction("POP AF", 0xF1, (z80) =>
                {
                    Pop(z80, z80.AF);
                    return Execution.Result(TStates.Count(10));
                }),

                new Instruction("POP IX", 0xDD, 0xE1, (z80) =>
                {
                    Pop(z80, z80.IX);
                    return Execution.Result(TStates.Count(14));
                }),

                new Instruction("POP IY", 0xFD, 0xE1, (z80) =>
                {
                    Pop(z80, z80.IY);
                    return Execution.Result(TStates.Count(14));
                })
            });
        }

        private void Pop(Z80 z80, Register16 register)
        {
            var lowValue = z80.Memory.Get(z80.SP.Value);
            z80.SP.Value++;

            var highValue = z80.Memory.Get(z80.SP.Value);
            z80.SP.Value++;

            register.Value = BitConverter.ToUInt16(new[] { highValue, lowValue }, 0);
        }
    }
}
