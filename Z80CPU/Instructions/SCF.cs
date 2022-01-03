using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Name.Carry, Affect.One)]
    [Flag(Name.HalfCarry, Affect.Zero)]
    [Flag(Name.Subraction, Affect.Zero)]
    public class SCF : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("SCF", 0x37, (z80) => 
            {
                return TStates.Count(4);
            }));
        }
    }
}
