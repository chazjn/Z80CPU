namespace Z80CPU.Instructions
{
    public class EI : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("EI", 0xFB, (z80) =>
            {
                z80.InteruptsEnabled = true;
                return Execution.Result(TStates.Count(4));
            }));
        }
    }
}
