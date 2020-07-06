using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Registers
{
    public class Flags : Register8
    {
        /* 7 |  S  | Sign             | 0 = positive, 1 = negative
         * 6 |  Z  | Zero             | 0 = non zero, 1 = zero
         * 5 |     |                  |
         * 4 |  H  | Half carry       | Holds carry from bit 3 to 4
         * 3 |     |                  |
         * 2 | P/V | Parity/overflow  | 0 = odd parity, 1 = even parity / overflow after arithmetic
         * 1 |  N  | Subtraction      | 0 = used addition, 1 = used subtraction
         * 0 |  C  | Carry            | Holds to carry
         */

        public bool Sign { get { return BitHelper.IsSet(Value, 7); } set { SetBit(7, value); } }

        public bool Zero { get { return BitHelper.IsSet(Value, 6); } set { SetBit(6, value); } }

        public bool HalfCarry { get { return BitHelper.IsSet(Value, 4); } set { SetBit(4, value); } }

        public bool ParityOrOverflow { get { return BitHelper.IsSet(Value, 2); } set { SetBit(2, value); } }

        public bool Subtraction { get { return BitHelper.IsSet(Value, 1); } set { SetBit(1, value); } }

        public bool Carry { get { return BitHelper.IsSet(Value, 0); } set { SetBit(0, value); } }

        public Flags() : base("F")
        {
        }

        public void SetSign(byte value)
        {
            Sign = BitHelper.IsSet(value, 7);
        }

        public void SetZero(byte value)
        {
            Zero = value == 0 ? true : false;
        }

        public void SetHalfCarry(byte before, byte after)
        {

        }

        public void SetSubtraction(bool value)
        {
            Subtraction = value;
        }

        public void SetCarry()
        {

        }

        private void SetBit(int index, bool value)
        {
            if (value == true)
            {
                Value = (byte)(Value | (1 << index));
            }
            else
            {
                Value = (byte)(Value & ~(1 << index));
            }
        }
    }
}