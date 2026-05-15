namespace Z80CPU.Instructions
{
    public class CPDR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("CPDR", 0xED, 0xB9, z80 =>
            {
                // TODO: repeat CPD until BC == 0 or A == (HL); 21 T-states if repeating, 16 if done
                return Execution.Result(TStates.Count(21));
            }));
        }
    }
}
