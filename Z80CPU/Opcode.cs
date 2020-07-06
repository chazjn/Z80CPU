using System;
using System.Collections.Generic;

namespace Z80CPU
{
    public class Opcode
    {
        public string Instruction => Name.Split(' ')[0];
        public string Name { get; }
        public IList<Oprand> Values { get; }
        private Action<Z80> Action { get; }
        
        public Opcode(string name, Oprand[] values, Action<Z80> action)
        {
            Name = name;
            Action = action;
            Values = values;
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

        public Opcode(string name, byte value, Action<Z80> action)
        {
            Name = name;
            Action = action;
            Values = new List<Oprand>
            {
                new Oprand(value)
            };
        }

        public bool IsMatch(IList<byte> bytes)
        {
            bool isMatch = false;

            for (int i = 0; i < bytes.Count; i++)
            {
                //first check there is a byte at this position to compare
                if(Values.Count -1 < i)
                {
                    break;
                }
                
                //second check if it is an 'Any' byte
                if (Values[i].IsAny)
                {
                    continue;
                }

                //third, compare the byte
                if(Values[i].Value == bytes[i])
                {
                    isMatch = true;
                }
                else
                {
                    isMatch = false;
                    break;
                }
            }
          
            return isMatch;
        }

        public void Execute(Z80 z80)
        {
            Action.Invoke(z80);
        }
    }
}
