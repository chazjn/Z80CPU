using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Name.HalfCarry, Affect.Reset)]
    [Flag(Name.ParityOrOverflow, Affect.Reset)]
    [Flag(Name.Subraction, Affect.Reset)]
    public class LDDR : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("LDDR", 0xED, 0xB8, (z80) =>
            {
                var value = z80.Memory.Get(z80.HL);
                z80.Memory.Set(z80.DE, value);

                z80.DE.Decrement();
                z80.HL.Decrement();
                z80.BC.Decrement();

                if (z80.BC.IsNotZero)
                {
                    z80.PC.Decrement();
                    z80.PC.Decrement();
                    return TStates.Count(21);
                }

                return TStates.Count(16);
            }));
        }
    }
}
