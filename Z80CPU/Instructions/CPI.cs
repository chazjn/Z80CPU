namespace Z80CPU.Instructions
{
    public class CPI : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("CPI", 0xED, 0xA1, z80 =>
            {
                // TODO: compare A with (HL), HL++, BC--; sets Z if match
                return Execution.Result(TStates.Count(16));
            }));
        }
    }
}
