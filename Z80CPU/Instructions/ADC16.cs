using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [FlagsCalculation(OperationType.AddWithCarry16,
        Sign = Affect.DefaultCalculation,
        Zero = Affect.DefaultCalculation,
        HalfCarry = Affect.DefaultCalculation,
        ParityOrOverflow = Affect.DefaultCalculation,
        Subtraction = Affect.Reset,
        Carry = Affect.DefaultCalculation)]
    public class ADC16 : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("ADC HL, BC", 0xED, 0x4A, z80 => { z80.HL.AddWithCarry(z80.BC.Value, z80.F.Carry); return Execution.Result(TStates.Count(15), z80.HL); }),
                new Instruction("ADC HL, DE", 0xED, 0x5A, z80 => { z80.HL.AddWithCarry(z80.DE.Value, z80.F.Carry); return Execution.Result(TStates.Count(15), z80.HL); }),
                new Instruction("ADC HL, HL", 0xED, 0x6A, z80 => { z80.HL.AddWithCarry(z80.HL.Value, z80.F.Carry); return Execution.Result(TStates.Count(15), z80.HL); }),
                new Instruction("ADC HL, SP", 0xED, 0x7A, z80 => { z80.HL.AddWithCarry(z80.SP.Value, z80.F.Carry); return Execution.Result(TStates.Count(15), z80.HL); }),
            });
        }
    }
}
