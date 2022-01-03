namespace Z80CPU
{
    public class TStates
    {
        public int Value { get; }

        private TStates(int value)
        {
            Value = value;
        }

        public static TStates Count(int value)
        {
            return new TStates(value);
        }
    }
}
