using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Affect.None)]
    public class EI : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("EI", 0xFB, (z80) =>
            {
                z80.InteruptsEnabled = true;
                return TStates.Count(4);
            }));
        }
    }
}
