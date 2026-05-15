namespace Z80CPU.Instructions
{
    public class RETN : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("RETN", 0xED, 0x45, z80 =>
            {
                // TODO: pop PC from stack, restore IFF1 from IFF2 (z80._iff2)
                return Execution.Result(TStates.Count(14));
            }));
        }
    }
}
