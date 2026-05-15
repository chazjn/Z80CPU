namespace Z80CPU.Instructions
{
    public class RETI : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("RETI", 0xED, 0x4D, z80 =>
            {
                // TODO: pop PC from stack, signal to daisy-chain devices that interrupt is done
                return Execution.Result(TStates.Count(14));
            }));
        }
    }
}
