using System;
using System.Collections.Generic;

namespace Z80CPU
{
    public class Opcode
    {
        public string Name { get; }
        public IList<Oprand> Values { get; }
        private Action<Z80> Action { get; }
        
        public Opcode(string name, Oprand[] values, Action<Z80> action)
        {
            Name = name;
            Action = action;
            Values = values;
        }

        public Opcode(string name, byte value, Action<Z80> action)
        {
            Name = name;
            Action = action;
            Values = new List<Oprand>
            {
                new Oprand(value)
            };
        }

        public Opcode(string name, byte value1, byte value2, Action<Z80> action)
        {
            Name = name;
            Action = action;
            Values = new List<Oprand>
            {
                new Oprand(value1),
                new Oprand(value2)
            };
        }

        public Opcode(string name, byte[] values, Action<Z80> action)
        {
            Name = name;
            Action = action;

            Values = new List<Oprand>();
            foreach (var value in values)
            {
                Values.Add(new Oprand(value));
            }
        }

        public bool IsMatch(IList<byte> bytes)
        {
            // if we have too many bytes then this will never match
            if (bytes.Count > Values.Count)
            {
                return false;
            }

            // if we have less or equal bytes, then let's check if this is a contender
            if (bytes.Count <= Values.Count)
            {
                for (int i = 0; i < bytes.Count; i++)
                {
                    //first check if it is an 'Any' byte
                    if (Values[i].IsAny)
                    {
                        continue;
                    }

                    //second, compare the byte
                    if (Values[i].Value != bytes[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Execute(Z80 z80)
        {
            Action.Invoke(z80);
        }
    }
}
