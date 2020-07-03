using System;
using System.Collections.Generic;

namespace Z80CPU
{
    public class Opcode
    {
        public string Name { get; }
        public IList<ByteValue> Bytes { get; }
        private Action<Z80> Action { get; }

        public Opcode(string name, ByteValue[] bytes, Action<Z80> action)
        {
            Name = name;
            Action = action;
            Bytes = bytes;
        }

        public Opcode(string name, byte[] bytes, Action<Z80> action)
        {
            Name = name;
            Action = action;

            Bytes = new List<ByteValue>();
            foreach (var _byte in bytes)
            {
                Bytes.Add(new ByteValue(_byte));
            }
        }

        public Opcode(string name, byte value, Action<Z80> action)
        {
            Name = name;
            Action = action;
            Bytes = new List<ByteValue>
            {
                new ByteValue(value)
            };
        }

        public bool IsMatch(IList<byte> bytes)
        {
            bool isMatch = false;

            for (int i = 0; i < bytes.Count; i++)
            {
                //first check there is a byte at this position to compare
                if(Bytes.Count -1 < i)
                {
                    break;
                }
                
                //second check if it is an 'Any' byte
                if (Bytes[i].IsAny)
                {
                    continue;
                }

                //third, compare the byte
                if(Bytes[i].Value == bytes[i])
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
