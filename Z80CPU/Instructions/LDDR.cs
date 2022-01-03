namespace Z80CPU.Instructions
{
    public class LDDR : Instruction
    {
        public LDDR()
        {
            Opcodes.Add(new Opcode("LDDR", 0xED, 0xB8, (z80) =>
            {
                var value = z80.Memory.Get(z80.HL.Value);
                z80.Memory.Set(z80.DE.Value, value);

                z80.DE.Value--;
                z80.HL.Value--;
                z80.BC.Value--;

                z80.F.HalfCarry = false;
                z80.F.ParityOrOverflow = false;
                z80.F.Subtraction = false;

                if(z80.BC.Value != 0)
                {
                    z80.PC.Value--;
                    z80.PC.Value--;
                }
            }));
        }

        protected override void AddOpcodes()
        {
            throw new System.NotImplementedException();
        }
    }
}
