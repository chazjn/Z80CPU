using Z80CPU.Registers;

namespace Z80CPU.Instructions
{
    [Flag(Name.HalfCarry, Affect.Reset)]
    [Flag(Name.ParityOrOverflow, Affect.CalculatedInOpcode)]
    [Flag(Name.Subraction, Affect.Reset)]
    public class LDI : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("LDI", 0xED, 0xA0, (z80) =>
            {
                var value = z80.Memory.Get(z80.HL.Value);
                z80.Memory.Set(z80.DE.Value, value);

                z80.DE.Value++;
                z80.HL.Value++;
                z80.BC.Value--;

                z80.F.ParityOrOverflow = !z80.BC.Value.IsZero();
                return Execution.Result(TStates.Count(16));
            }));
        }
    }
}
