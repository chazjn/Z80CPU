namespace Z80CPU.Instructions
{
    public class NOP : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("NOP", 0x0, (z80) =>
            {
                return Execution.Result(TStates.Count(4));
            }));
        }
    }
}
