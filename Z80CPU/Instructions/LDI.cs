namespace Z80CPU.Instructions
{
    public class LDI : Instruction
    {
        public LDI()
        {
            Opcodes.Add(new Opcode("LDI", 0xED, 0xA0, (z80) =>
            {
                var value = z80.Memory.Get(z80.HL.Value);
                z80.Memory.Set(z80.DE.Value, value);

                z80.DE.Value++;
                z80.HL.Value++;
                z80.BC.Value--;

                z80.F.HalfCarry = false;
                z80.F.ParityOrOverflow = z80.BC.Value == 0 ? false : true;
                z80.F.Subtraction = false;
            }));
        }
    }
}
