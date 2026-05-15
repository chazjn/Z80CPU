namespace Z80CPU.Instructions
{
    public class RRCA : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("RRCA", 0x0F, z80 =>
            {
                // TODO: rotate A right; bit 0 goes to carry and to bit 7
                return Execution.Result(TStates.Count(4));
            }));
        }
    }
}
