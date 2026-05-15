namespace Z80CPU.Instructions
{
    public class INDR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("INDR", 0xED, 0xBA, z80 =>
            {
                // TODO: repeat IND until B == 0; 21 T-states if B != 0 after, 16 if B == 0
                return Execution.Result(TStates.Count(21));
            }));
        }
    }
}
