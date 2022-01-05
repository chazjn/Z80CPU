namespace Z80CPU.Registers
{
    public class Register8
    {
        public string Name { get; }

        public virtual byte Value { get; set; }

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
    }
}
