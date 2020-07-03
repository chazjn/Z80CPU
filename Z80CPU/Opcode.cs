using System;
using System.Collections.Generic;

namespace Z80CPU
{
    public class Opcode
    {
        public string Name { get; }
        public IList<ByteValue> Bytes { get; }
        private Action<Z80> Action { get; }

        public Opcode(string name, ByteValue[] bytes, Action<Z80> action)
        {
            Name = name;
            Action = action;
            Bytes = bytes;
        }

        public Opcode(string name, byte[] bytes, Action<Z80> action)
        {
            Name = name;
            Action = action;

            Bytes = new List<ByteValue>();
            foreach (var _byte in bytes)
            {
                Bytes.Add(new ByteValue(_byte));
            }
        }

        public void Execute(Z80 z80)
        {
            Action.Invoke(z80);
        }
    }
}
