namespace Z80CPU.Instructions
{
    public class EXX : Instruction_OLD
    {
        public EXX() : base("EXX", 0xD9)
        {
        }

        public override void Execute(Z80 z80)
        {
            var tempBC = z80.BC.Value;
            var tempDE = z80.DE.Value;
            var tempHL = z80.HL.Value;

            z80.BC.Value = z80._BC_.Value;
            z80.DE.Value = z80._DE_.Value;
            z80.HL.Value = z80._HL_.Value;

            z80._BC_.Value = tempBC;
            z80._DE_.Value = tempDE;
            z80._HL_.Value = tempHL;
        }
    }
}
