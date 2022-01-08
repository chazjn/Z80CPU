using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Affect.None)]
    public class EI : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("EI", 0xFB, (z80) =>
            {
                z80.InteruptsEnabled = true;
                return TStates.Count(4);
            }));
        }
    }
}
