using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU
{
    public class Oprand
    {
        public byte? Value { get; }
        public bool IsAny { get; }
        public static Oprand Any => new Oprand(null, true);

        private Oprand(byte? value, bool isAny)
        {
            Value = value;
            IsAny = isAny;
        }
        
        public static Oprand Parse(byte value)
        {
            return new Oprand(value, false);
        }
    }
}
