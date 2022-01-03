using System;
using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU
{
    public class Opcode
    {
        public string Name { get; }
        public IList<Oprand> Values { get; }
        public Func<Z80, TStates> Action { get; internal set; }

        public Affect? FlagSign { get; internal set; }
        public Affect? FlagZero { get; internal set; }
        public Affect? FlagHalfCarry { get; internal set; }
        public Affect? FlagParity { get; internal set; }
        public Affect? FlagOverflow { get; internal set; }
        public Affect? FlagSubtraction { get; internal set; }
        public Affect? FlagCarry { get; internal set; }

        public Opcode(string name, byte value, Func<Z80, TStates> action)
        {
            Name = name;
            Action = action;
            Values = new List<Oprand>
            {
                Oprand.Parse(value)
            };
        }

        public Opcode(string name, byte value1, byte value2, Func<Z80, TStates> action)
        {
            Name = name;
            Action = action;
            Values = new List<Oprand>
            {
                Oprand.Parse(value1),
                Oprand.Parse(value2)
            };
        }

        public Opcode(string name, byte value1, Oprand value2, Func<Z80, TStates> action)
        {
            Name = name;
            Action = action;
            Values = new List<Oprand>
            {
                Oprand.Parse(value1),
                value2
            };
        }

        public Opcode(string name, byte value1, byte value2, Oprand value3, Func<Z80, TStates> action)
        {
            Name = name;
            Action = action;
            Values = new List<Oprand>
            {
                Oprand.Parse(value1),
                Oprand.Parse(value2),
                value3
            };
        }

        public Opcode(string name, byte value1, Oprand value2, Oprand value3, Func<Z80, TStates> action)
        {
            Name = name;
            Action = action;
            Values = new List<Oprand>
            {
                Oprand.Parse(value1),
                value2,
                value3
            };
        }

        public Opcode(string name, byte value1, byte value2, Oprand value3, byte value4, Func<Z80, TStates> action)
        {
            Name = name;
            Values = new List<Oprand>
            {
                Oprand.Parse(value1),
                Oprand.Parse(value2),
                value3,
                Oprand.Parse(value4)
            };
            Action = action;    
        }
        
        public TStates Execute(Z80 z80)
        {
            return Action.Invoke(z80);
        }
    }
}
