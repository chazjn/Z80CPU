namespace Z80CPU.Instructions
{
    public class OUTI : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("OUTI", 0xED, 0xA3, z80 =>
            {
                // TODO: write (HL) → port (C), HL++, B--
                return Execution.Result(TStates.Count(16));
            }));
        }
    }
}
