using System;
using System.Collections.Generic;

namespace Z80CPU
{
    public abstract class Instruction
    {
        public List<Opcode> Opcodes { get; } = new List<Opcode>();
    }
}
