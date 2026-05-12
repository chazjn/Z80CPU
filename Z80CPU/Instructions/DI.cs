namespace Z80CPU.Instructions
{
    public class DI : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("DI", 0xF3, (z80) => 
            { 
                z80.InteruptsEnabled = false;
                return TStates.Count(4);
            }));
        }
    }
}
