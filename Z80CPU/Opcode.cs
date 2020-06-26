using System;
using System.Collections.Generic;

namespace Z80CPU
{
    public class Opcode
    {
        public string Name { get; }
        public IList<OpcodeByte> Bytes { get; }
        private Action<Z80> Action { get; }

        public Opcode(string name, OpcodeByte opcodeByte, Action<Z80> action)
        {
            Name = name;
            Bytes = new List<OpcodeByte> { opcodeByte };
            Action = action;
        }

        public Opcode(string name, OpcodeByte[] opcodeBytes, Action<Z80> action)
        {
            Name = name;
            Bytes = new List<OpcodeByte>(opcodeBytes);
            Action = action;
        }

        public void Execute(Z80 z80)
        {
            Action.Invoke(z80);
        }
    }
}
