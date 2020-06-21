using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public abstract class Instruction_OLD
    {
        private List<byte> _opcodes { get; set; } = new List<byte>();
        private List<byte> _parameters { get; set; } = new List<byte>();

        public string Name { get; private set; }
        public int ParametersRequired { get; private set; }
        public IReadOnlyList<byte> Opcodes { get { return _opcodes; } }
        public IReadOnlyList<byte> Parameters { get { return _parameters; } }

        public IReadOnlyList<byte> RawBytes
        {
            get
            {
                var list = new List<byte>();
                list.AddRange(Opcodes);
                list.AddRange(Parameters);
                return list;
            }
        }

        public Instruction_OLD(string name, byte opcode, int parametersRequired = 0)
        {
            Name = name;
            _opcodes.Add(opcode);
            ParametersRequired = parametersRequired;
        }

        public Instruction_OLD(string name, byte opcode1, byte opcode2, int parametersRequired = 0)
        {
            Name = name;
            _opcodes.Add(opcode1);
            _opcodes.Add(opcode2);
            ParametersRequired = parametersRequired;
        }

        public void AddParameter(byte value)
        {
            _parameters.Add(value);
        }

        public abstract void Execute(Z80 z80);
    }
}