namespace Z80CPU.Instructions
{
    public class OTDR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("OTDR", 0xED, 0xBB, z80 =>
            {
                // TODO: repeat OUTD until B == 0; 21 T-states if B != 0 after, 16 if B == 0
                return Execution.Result(TStates.Count(21));
            }));
        }
    }
}
