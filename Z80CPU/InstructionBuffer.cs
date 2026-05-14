using System.Collections.Generic;

namespace Z80CPU
{
    internal class InstructionBuffer
    {
        private readonly List<byte> _bytes = new List<byte>();

        public byte  Immediate    => _bytes[1];
        public sbyte Offset       => (sbyte)_bytes[1];
        public sbyte Displacement => (sbyte)_bytes[2];

        public void Add(byte value) => _bytes.Add(value);
        public void Clear()         => _bytes.Clear();
        public int Count            => _bytes.Count;
        public byte this[int index] => _bytes[index];
    }
}
