using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [FlagsCalculation(
        Carry = Affect.Set,
        HalfCarry = Affect.Reset,
        Subtraction = Affect.Reset)]
    public class SCF : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("SCF", 0x37, (z80) => 
            {
                return Execution.Result(TStates.Count(4));
            }));
        }
    }
}
