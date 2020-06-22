namespace Z80CPU.Registers
{
    public class Register8
    {
        protected byte _value;

        public string Name { get; }

        public virtual byte Value
        {
            get
            {
                return _value;
            }

            set
            {
                if(value != _value)
                {
                    _value = value;
                }
            }
        }

        public Register8(string name)
        {
            Name = name;
        }

        public bool GetBit(int index)
        {
            return BitHelper.IsSet(_value, index);
        }

        protected void SetBit(int index, bool value)
        {
            if (value == true)
            {
                _value = (byte)(_value | (1 << index));
            }
            else
            {
                _value = (byte)(_value & ~(1 << index));
            }
        }
    }
}
