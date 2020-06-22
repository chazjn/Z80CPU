using System;

namespace Z80CPU.Instructions
{
    public class Opcode
    {
        public string Name { get; }
        public byte Byte1 { get; }
        public byte? Byte2 { get; }
        public OpcodeParameter OpcodeParameter { get; }

        private Action<Z80, byte[]> Action { get; }

        public Opcode(string name, byte byte1, byte? byte2, OpcodeParameter opcodeParameter, Action<Z80, byte[]> action)
        {
            Name = name;
            Byte1 = byte1;
            Byte2 = byte2;
            OpcodeParameter = opcodeParameter;
            Action = action;
        }

        public void Execute(Z80 z80, byte[] buffer)
        {
            Action.Invoke(z80, buffer);
        }
    }
}
