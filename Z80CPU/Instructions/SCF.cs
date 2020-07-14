namespace Z80CPU.Instructions
{
    public class SCF : Instruction
    {
        public SCF()
        {
            Opcodes.Add(new Opcode("SCF", 0x37, (z80) =>
            {
                z80.F.HalfCarry = false;
                z80.F.Sign = false;
                z80.F.Carry = true;
            }));
        }
    }
}
