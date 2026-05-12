namespace Z80CPU
{
    public class EncodingByte
    { 
        public byte? Value { get; }
        public bool IsVariable { get; }
        public static EncodingByte Variable => new EncodingByte(null, true);

        private EncodingByte(byte? value, bool isVariable)
        {
            Value = value;
            IsVariable = isVariable;
        }
        
        public static EncodingByte Fixed(byte value)
        {
            return new EncodingByte(value, false);
        }
    }
}
