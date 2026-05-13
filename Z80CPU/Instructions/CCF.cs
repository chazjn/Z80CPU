using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Name.Carry, Affect.Invert)]
    [Flag(Name.HalfCarry, Affect.Invert)]
    [Flag(Name.Subraction, Affect.Reset)]
    public class CCF : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("CCF", 0x3F, (z80) => 
            {
                return Execution.Result(TStates.Count(4));
            }));
        }
    }
}
