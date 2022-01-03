namespace Z80CPU.Instructions
{
    public class NOP : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("NOP", 0x0, (z80) =>
            {
                return TStates.Count(4);
            }));
        }
    }
}
