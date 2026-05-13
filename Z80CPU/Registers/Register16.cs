using System;

namespace Z80CPU.Registers
{
    public class Register16 : IRegisterResult
    {
        internal Register8 High { get; }
        internal Register8 Low { get; }

        public string Name { get; private set; }

        public ushort PreviousValue { get; private set; }
        public int RawSum { get; private set; }

        public ushort Value
        {
            get => BitConverter.ToUInt16(new byte[2] { Low.Value, High.Value }, 0);
            set
            {
                PreviousValue = Value;
                High.Value = (byte)(value >> 8);
                Low.Value = (byte)(value & 255);
            }
        }

        public bool IsZero => Value == 0;
        public bool IsNotZero => Value != 0;

        public Register16(string name)
        {
            Name = name;
            High = new Register8($"{name}(HIGH)");
            Low = new Register8($"{name}(LOW)");
        }

        public Register16(Register8 high, Register8 low)
        {
            Name = high.Name + low.Name;
            High = high;
            Low = low;
        }

        public void Add(ushort operand)
        {
            RawSum = Value + operand;
            Value = (ushort)RawSum;
        }

        public void AddWithCarry(ushort operand, bool carry)
        {
            RawSum = Value + operand + (carry ? 1 : 0);
            Value = (ushort)RawSum;
        }

        public void Increment()
        {
            Value = (ushort)(Value + 1);
        }

        public void Decrement()
        {
            Value = (ushort)(Value - 1);
        }
    }
}
