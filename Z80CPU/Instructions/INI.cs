namespace Z80CPU.Instructions
{
    public class INI : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("INI", 0xED, 0xA2, z80 =>
            {
                // TODO: read port (C) → (HL), HL++, B--
                return Execution.Result(TStates.Count(16));
            }));
        }
    }
}
