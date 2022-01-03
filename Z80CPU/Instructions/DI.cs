namespace Z80CPU.Instructions
{
    public class DI : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("DI", 0xF3, (z80) => 
            { 
                z80.InteruptsEnabled = false;
                return TStates.Count(4);
            }));
        }
    }
}
