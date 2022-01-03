using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Name.HalfCarry, Affect.Zero)]
    [Flag(Name.ParityOrOverflow, Affect.Zero)]
    [Flag(Name.Subraction, Affect.Zero)]
    public class LDIR : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("LDIR", 0xED, 0xB0, (z80) =>
            {
                var value = z80.Memory.Get(z80.HL.Value);
                z80.Memory.Set(z80.DE.Value, value);

                z80.DE.Value++;
                z80.HL.Value++;
                z80.BC.Value--;

                if (z80.BC.Value.IsZero())
                {
                    return TStates.Count(16);
                }
                else
                {
                    z80.PC.Value--;
                    z80.PC.Value--;
                    return TStates.Count(21);
                }
            }));
        }
    }
}
