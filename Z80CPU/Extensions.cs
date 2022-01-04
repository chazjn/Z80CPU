namespace Z80CPU
{
    public static class Extensions
    {
        public static byte GetBit(this byte value, int position)
        {
            return (byte)((value >> position) & 1);
        }

        public static bool IsZero(this byte value)
        {
            return value == 0;
        }

        public static byte ShiftLeftBy(this byte value, int position)
        {
            return (byte)(value << position);
        }

        public static byte ShiftRight(this byte value, int position)
        {
            return (byte)(value >> position);
        }

        public static bool IsZero(this ushort value)
        {
            return value == 0;
        }

        public static bool IsNotZero(this ushort value)
        {
            return value != 0;
        }
    }
}
