namespace Z80CPU.Instructions
{
    public class CPD : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("CPD", 0xED, 0xA9, z80 =>
            {
                // TODO: compare A with (HL), HL--, BC--; sets Z if match
                return Execution.Result(TStates.Count(16));
            }));
        }
    }
}
