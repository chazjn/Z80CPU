using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [FlagsCalculation(
        HalfCarry = Affect.Reset,
        ParityOrOverflow = Affect.Reset,
        Subtraction = Affect.Reset)]
    public class LDDR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("LDDR", 0xED, 0xB8, (z80) =>
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
                    return Execution.Result(TStates.Count(21));
                }

                return Execution.Result(TStates.Count(16));
            }));
        }
    }
}
