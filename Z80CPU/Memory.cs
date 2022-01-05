using System;
using Z80CPU.Registers;

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

        public byte Get(Register16 register)
        {
            return Get(register.Value);
        }

        public virtual byte Get(ushort index)
        {
            if(index < 0 || index > Bytes.Length - 1)
            {
                throw new ArgumentOutOfRangeException("index", "Out of range of memory size");
            }

            return Bytes[index];
        }

        public void Set(Register16 index, byte value)
        {
            Set(index.Value, value);
        }

        public abstract void Set(ushort index, byte value);
    }
}
