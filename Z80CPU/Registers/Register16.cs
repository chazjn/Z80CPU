using System;

namespace Z80CPU.Registers
{
    public class Register16
    {
        private readonly Register8 _lsb;
        private readonly Register8 _msb;

        public string Name { get; private set; }
        public ushort Value
        {
            get
            {
                return BitConverter.ToUInt16(new byte[2] { _msb.Value, _lsb.Value }, 0);
            }
            set
            {
                _lsb.Value = (byte)(value >> 8);
                _msb.Value = (byte)(value & 255);
            }
        }

        public Register16(string name)
        {
            Name = name;
            _lsb = new Register8("LSB");
            _msb = new Register8("MSB");
        }

        public Register16(Register8 lsb, Register8 msb)
        {
            Name = lsb.Name + msb.Name;
            _lsb = lsb;
            _msb = msb;
        }
    }
}
