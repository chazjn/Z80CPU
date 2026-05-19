using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [FlagsCalculation(
        Subtraction = Affect.Reset,
        HalfCarry = Affect.InstructionCalculation,
        Carry = Affect.InstructionCalculation)]
    public class CCF : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("CCF", 0x3F, (z80) =>
            {
                z80.F.HalfCarry = z80.F.Carry;
                z80.F.Carry = !z80.F.Carry;
                return Execution.Result(TStates.Count(4));
            }));
        }
    }
}
