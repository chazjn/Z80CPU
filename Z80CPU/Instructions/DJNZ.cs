namespace Z80CPU.Instructions
{
    public class DJNZ : Instruction
    {        
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("DJNZ e", 0x10, (z80) =>
            {
                z80.B.Value--;

                if (z80.B.Value.IsZero())
                {
                    var offset = z80.Memory.Get(z80.PC.Value);
                    var pc = z80.PC.Value + (sbyte)offset;
                    z80.PC.Value = (ushort)pc;
                    return TStates.Count(8);
                }
                else
                {
                    //increment PC to skip the offset
                    z80.PC.Increment();
                    return TStates.Count(13);
                }
            }));
        }
    }
}
