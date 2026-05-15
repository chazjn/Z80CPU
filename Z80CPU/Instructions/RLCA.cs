namespace Z80CPU.Instructions
{
    public class RLCA : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("RLCA", 0x07, z80 =>
            {
                // TODO: rotate A left; bit 7 goes to carry and to bit 0
                return Execution.Result(TStates.Count(4));
            }));
        }
    }
}
