namespace Z80CPU.Instructions
{
    public class CPIR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("CPIR", 0xED, 0xB1, z80 =>
            {
                // TODO: repeat CPI until BC == 0 or A == (HL); 21 T-states if repeating, 16 if done
                return Execution.Result(TStates.Count(21));
            }));
        }
    }
}
