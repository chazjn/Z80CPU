using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU
{
    public class ByteValue
    {
        public byte? Value { get; }
        public bool IsAny { get; }
        public static ByteValue Any 
        {
            get
            {
                return new ByteValue();
            }
       }

        public ByteValue(byte value)
        {
            Value = value;
            IsAny = false;
        }

        private ByteValue()
        {
            Value = null;
            IsAny = true;
        }
    }
}
