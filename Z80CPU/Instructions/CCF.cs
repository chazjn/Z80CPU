using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Name.Carry, Affect.Invert)]
    [Flag(Name.HalfCarry, Affect.Invert)]
    [Flag(Name.Subraction, Affect.Zero)]
    public class CCF : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("CCF", 0x3F, (z80) => 
            {
                return TStates.Count(4);
            }));
        }
    }
}
