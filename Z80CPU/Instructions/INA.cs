namespace Z80CPU.Instructions
{
    public class INA : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("IN A, (N)", 0xDB, EncodingByte.Variable, (z80) =>
            {
                var low = z80.Buffer[1];
                var address = ByteHelper.CreateUShort(z80.A.Value, low);
                z80.A.Value = z80.Ports.GetByte(address);
                return Execution.Result(TStates.Count(11));
            }));
        }
    }
}
