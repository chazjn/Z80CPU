namespace Z80CPU
{
    public class OpcodeByte
    {
        public byte Value { get; }
        public bool IsParameter { get; }

        public OpcodeByte(byte value)
        {
            Value = value;
            IsParameter = false;
        }

        public OpcodeByte()
        {
            Value = 0;
            IsParameter = true;
        }
    }
}
