using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public enum OpcodeParameter
    {
        None,
        EightBitValue,
        EightBitOffset,
        Register,
        High,
        Low,
    }
}
