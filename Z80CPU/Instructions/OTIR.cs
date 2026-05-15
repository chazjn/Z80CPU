namespace Z80CPU.Instructions
{
    public class OTIR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("OTIR", 0xED, 0xB3, z80 =>
            {
                // TODO: repeat OUTI until B == 0; 21 T-states if B != 0 after, 16 if B == 0
                return Execution.Result(TStates.Count(21));
            }));
        }
    }
}
