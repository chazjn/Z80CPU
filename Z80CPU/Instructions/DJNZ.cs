namespace Z80CPU.Instructions
{
    public class DJNZ : Mnemonic
    {        
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("DJNZ e", 0x10, (z80) =>
            {
                z80.B.Value--;

                if (z80.B.Value.IsNotZero())
                {
                    var offset = z80.Memory.Get(z80.PC.Value);
                    var pc = z80.PC.Value + (sbyte)offset;
                    z80.PC.Value = (ushort)pc;
                    return Execution.Result(TStates.Count(13));
                }
                else
                {
                    //increment PC to skip the offset
                    z80.PC.Increment();
                    return Execution.Result(TStates.Count(8));
                }
            }));
        }
    }
}
