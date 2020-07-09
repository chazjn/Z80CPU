namespace Z80CPU.Instructions
{
    public class NOP : Instruction
    {
        public NOP()
        {
            Opcodes.Add(new Opcode("NOP", 0x0, (z80) =>
            {
                //do nothing
            }));
        }
    }
}
