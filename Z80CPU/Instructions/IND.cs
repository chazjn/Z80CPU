using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Name.Sign, Affect.Undefined)]
    [Flag(Name.Zero, Affect.CalculatedInOpcode)]
    [Flag(Name.HalfCarry, Affect.Undefined)]
    [Flag(Name.ParityOrOverflow, Affect.Undefined)]
    [Flag(Name.Subraction, Affect.One)]
    public class IND : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("IND", 0xED, 0xAA, (z80) =>
            {
                var value = z80.Ports.GetByte(z80.C.Value);
                z80.Memory.Set(z80.HL.Value, value);

                z80.HL.Value--;
                z80.B.Value--;

                z80.F.Zero = z80.B.Value.IsZero();

                return TStates.Count(16);
            }));
        }
    }
}
