using System;
using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU
{
    public class Instruction
    {
        public string Name { get; }
        public IList<EncodingByte> Values { get; }
        public FlagsCalculationAttribute Flags { get; internal set; }
        public Func<Z80, Execution> Action { get; internal set; }

        public Instruction(string name, byte value, Func<Z80, Execution> action)
        {
            Name = name;
            Action = action;
            Values = new List<EncodingByte>
            {
                EncodingByte.Fixed(value)
            };
        }

        public Instruction(string name, byte value1, byte value2, Func<Z80, Execution> action)
        {
            Name = name;
            Action = action;
            Values = new List<EncodingByte>
            {
                EncodingByte.Fixed(value1),
                EncodingByte.Fixed(value2)
            };
        }

        public Instruction(string name, byte value1, EncodingByte value2, Func<Z80, Execution> action)
        {
            Name = name;
            Action = action;
            Values = new List<EncodingByte>
            {
                EncodingByte.Fixed(value1),
                value2
            };
        }

        public Instruction(string name, byte value1, byte value2, EncodingByte value3, Func<Z80, Execution> action)
        {
            Name = name;
            Action = action;
            Values = new List<EncodingByte>
            {
                EncodingByte.Fixed(value1),
                EncodingByte.Fixed(value2),
                value3
            };
        }

        public Instruction(string name, byte value1, EncodingByte value2, EncodingByte value3, Func<Z80, Execution> action)
        {
            Name = name;
            Action = action;
            Values = new List<EncodingByte>
            {
                EncodingByte.Fixed(value1),
                value2,
                value3
            };
        }

        public Instruction(string name, byte value1, byte value2, EncodingByte value3, EncodingByte value4, Func<Z80, Execution> action)
        {
            Name = name;
            Values = new List<EncodingByte>
            {
                EncodingByte.Fixed(value1),
                EncodingByte.Fixed(value2),
                value3,
                value4
            };
            Action = action;
        }

        public Instruction(string name, byte value1, byte value2, EncodingByte value3, byte value4, Func<Z80, Execution> action)
        {
            Name = name;
            Values = new List<EncodingByte>
            {
                EncodingByte.Fixed(value1),
                EncodingByte.Fixed(value2),
                value3,
                EncodingByte.Fixed(value4)
            };
            Action = action;
        }
        
        public Execution Execute(Z80 z80)
        {
            return Action.Invoke(z80);
        }
    }
}
