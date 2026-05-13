using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [FlagsCalculation(
        Sign = Affect.Undefined,
        Zero = Affect.InstructionCalculation,
        HalfCarry = Affect.Undefined,
        ParityOrOverflow = Affect.Undefined,
        Subtraction = Affect.Set)]
    public class IND : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("IND", 0xED, 0xAA, (z80) =>
            {
                var value = z80.Ports.GetByte(z80.C.Value);
                z80.Memory.Set(z80.HL.Value, value);

                z80.HL.Value--;
                z80.B.Value--;

                z80.F.Zero = z80.B.Value.IsZero();

                return Execution.Result(TStates.Count(16));
            }));
        }
    }
}
