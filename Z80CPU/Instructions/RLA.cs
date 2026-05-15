namespace Z80CPU.Instructions
{
    public class RLA : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("RLA", 0x17, z80 =>
            {
                // TODO: rotate A left through carry; old carry goes to bit 0, bit 7 goes to carry
                return Execution.Result(TStates.Count(4));
            }));
        }
    }
}
