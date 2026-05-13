using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    [Flag(Name.HalfCarry, Affect.Reset)]
    [Flag(Name.ParityOrOverflow, Affect.Reset)]
    [Flag(Name.Subraction, Affect.Reset)]
    public class LDIR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("LDIR", 0xED, 0xB0, (z80) =>
            {
                var value = z80.Memory.Get(z80.HL.Value);
                z80.Memory.Set(z80.DE.Value, value);

                z80.DE.Value++;
                z80.HL.Value++;
                z80.BC.Value--;

                if (z80.BC.Value.IsZero())
                {
                    return Execution.Result(TStates.Count(16));
                }
                else
                {
                    z80.PC.Value--;
                    z80.PC.Value--;
                    return Execution.Result(TStates.Count(21));
                }
            }));
        }
    }
}
