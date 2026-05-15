namespace Z80CPU.Instructions
{
    public class OUTD : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("OUTD", 0xED, 0xAB, z80 =>
            {
                // TODO: write (HL) → port (C), HL--, B--
                return Execution.Result(TStates.Count(16));
            }));
        }
    }
}
