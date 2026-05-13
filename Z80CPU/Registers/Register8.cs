namespace Z80CPU.Registers
{
    public class Register8 : IRegisterResult
    {
        public string Name { get; }

        private byte _value;

        public byte PreviousValue { get; private set; }

        public byte Value
        {
            get => _value;
            set
            {
                PreviousValue = _value;
                _value = value;
            }
        }

        ushort IRegisterResult.PreviousValue => PreviousValue;
        ushort IRegisterResult.Value => Value;

        public Register8(string name)
        {
            Name = name;
        }

        public Register8 Clone()
        {
            return new Register8(Name)
            {
                Value = Value
            };
        }

        public void Increment()
        {
            Value++;
        }

        public void Decrement()
        {
            Value--;
        }

        public void Add(byte value)
        {
            Value = (byte)(Value + value);
        }
    }
}
