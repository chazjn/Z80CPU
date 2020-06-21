namespace Z80CPU
{
    public class RAM : Memory
    {
        public RAM(ushort length) : base(length)
        {
        }

        public override void Set(ushort index, byte value)
        {
            Bytes[index] = value;
        }
    }
}
