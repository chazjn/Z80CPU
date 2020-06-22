using System;
using System.Collections.Generic;
using System.Linq;

namespace Z80CPU
{
    public class Opcode
    {
        public string Name { get; }
        public IList<byte> Bytes { get; }
        public OpcodeParameter OpcodeParameter { get; }

        private Action<Z80> Action { get; }

        public Opcode(string name, byte byte1, Action<Z80> action)
        {
            Name = name;
            Bytes = new List<byte> { byte1 };
            OpcodeParameter = OpcodeParameter.None;
            Action = action;
        }

        public Opcode(string name, byte[] bytes, Action<Z80> action)
        {
            Name = name;
            Bytes = bytes.ToList();
            OpcodeParameter = OpcodeParameter.None;
            Action = action;
        }

        public Opcode(string name, byte byte1, OpcodeParameter opcodeParameter, Action<Z80> action)
        {
            Name = name;
            Bytes = new List<byte> { byte1 };
            OpcodeParameter = opcodeParameter;
            Action = action;
        }

        public Opcode(string name, byte[] bytes, OpcodeParameter opcodeParameter, Action<Z80> action)
        {
            Name = name;
            Bytes = bytes.ToList();
            OpcodeParameter = opcodeParameter;
            Action = action;
        }

        public void Execute(Z80 z80)
        {
            Action.Invoke(z80);
        }
    }
}
