using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Name.HalfCarry, Affect.Zero)]
    [Flag(Name.ParityOrOverflow, Affect.CalculatedInOpcode)]
    [Flag(Name.Subraction, Affect.Zero)]
    public class LDI : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("LDI", 0xED, 0xA0, (z80) =>
            {
                var value = z80.Memory.Get(z80.HL.Value);
                z80.Memory.Set(z80.DE.Value, value);

                z80.DE.Value++;
                z80.HL.Value++;
                z80.BC.Value--;

                z80.F.ParityOrOverflow = !z80.BC.Value.IsZero();
                return TStates.Count(16);
            }));
        }
    }
}
