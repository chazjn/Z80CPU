using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU
{
    public static class Extensions
    {
        public static int GetBit(this byte byteValue, int position)
        {
            return (byteValue >> position) & 1;
        }

    }
}
