using System;

namespace Z80CPU
{
    public abstract class Memory
    {
        protected byte[] Bytes;
        public ushort Size { get { return (ushort)Bytes.Length; } }

        public Memory(ushort length)
        {
            Bytes = new byte[length];
        }

        public virtual byte Get(int index)
        {
            if(index < 0 || index > Bytes.Length - 1)
            {
                throw new ArgumentOutOfRangeException("index", "Out of range of memory size");
            }

            return Bytes[index];
        }

        public abstract void Set(ushort index, byte value);
    }
}
