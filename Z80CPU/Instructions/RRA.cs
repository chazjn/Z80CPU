namespace Z80CPU.Instructions
{
    public class RRA : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("RRA", 0x1F, z80 =>
            {
                // TODO: rotate A right through carry; old carry goes to bit 7, bit 0 goes to carry
                return Execution.Result(TStates.Count(4));
            }));
        }
    }
}
