using System;

namespace Z80CPU
{
    public static class BitHelper
    {
        public static bool IsSet(byte value, int index)
        {
            if(index < 0 || index > 7)
            {
                throw new IndexOutOfRangeException("index must be between 0 and 7");
            }

            return ((value >> index) & 1) == 1;
        }

        public static bool IsSet(ushort value, int index)
        {
            if (index < 0 || index > 65534)
            {
                throw new IndexOutOfRangeException("index must be between 0 and 65534");
            }

            return ((value >> index) & 1) == 1;
        }
    }
}