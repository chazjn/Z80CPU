using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU
{
    public class Oprand
    {
        public byte? Value { get; }
        public bool IsAny { get; }
        public static Oprand Any 
        {
            get
            {
                return new Oprand();
            }
       }

        public Oprand(byte value)
        {
            Value = value;
            IsAny = false;
        }

        private Oprand()
        {
            Value = null;
            IsAny = true;
        }
    }
}
