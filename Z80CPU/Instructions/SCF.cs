using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Name.Carry, Affect.Set)]
    [Flag(Name.HalfCarry, Affect.Reset)]
    [Flag(Name.Subraction, Affect.Reset)]
    public class SCF : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("SCF", 0x37, (z80) => 
            {
                return TStates.Count(4);
            }));
        }
    }
}
