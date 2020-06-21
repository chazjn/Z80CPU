namespace Z80CPU.Registers
{
    public class ProgramCounter : Register16
    {
        public ProgramCounter() : base("PC")
        {
        }

        public void Increment()
        {
            Value = (ushort)(Value + 1);
        }
    }
}
