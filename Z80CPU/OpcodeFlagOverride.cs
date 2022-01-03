using System;
using System.Collections.Generic;
using System.Text;
using Z80CPU.Flags;

namespace Z80CPU
{
    public class OpcodeFlagOverride
    {
        public Affect? FlagSign { get; set; }
        public Affect? FlagZero { get; set; }
        public Affect? FlagHalfCarry { get; set; }
        public Affect? FlagParity { get; set; }
        public Affect? FlagOverflow { get; set; }
        public Affect? FlagSubtraction { get; set; }
        public Affect? FlagCarry { get; set; }

        public IList<Opcode> Create(Affect? flagSign = null, params Opcode[] opcodes)
        {
            foreach (var opcode in opcodes)
            {
                opcode.FlagSign = FlagSign;
                opcode.FlagZero = FlagZero;
                opcode.FlagHalfCarry = FlagHalfCarry;
                opcode.FlagParity = FlagParity;
                opcode.FlagOverflow = FlagOverflow;
                opcode.FlagSubtraction = FlagSubtraction;
                opcode.FlagCarry = FlagCarry;
            }

            return opcodes;
        }
    }
}
