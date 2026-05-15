namespace Z80CPU.Instructions
{
    public class INIR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("INIR", 0xED, 0xB2, z80 =>
            {
                // TODO: repeat INI until B == 0; 21 T-states if B != 0 after, 16 if B == 0
                return Execution.Result(TStates.Count(21));
            }));
        }
    }
}
