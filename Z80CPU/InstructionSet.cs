using System;
using System.Collections.Generic;
using System.Linq;
using Z80CPU.Instructions;

namespace Z80CPU
{
    public class InstructionSet
    {
        public List<Opcode> Opcodes { get; }

        public InstructionSet()
        {
            Opcodes = new List<Opcode>();
            Opcodes.AddRange(new Add().Opcodes);
        }

        public Opcode GetOpcode(IList<byte> bytes)
        {
            if(bytes.Count == 1)
            {
                var matched = Opcodes.Where(o => o.Bytes.Count == 1 
                                              && o.OpcodeParameter.Index == -1 
                                              && o.Bytes[0] == bytes[0]);

                if(matched.Count() == 1)
                {
                    return matched.First();
                }
                else
                {
                    return null;
                }
            }
            



            if(bytes.Count == 2)
            {
                var matched = Opcodes.Where(o => (o.Bytes.Count == 2
                                              && o.OpcodeParameter.Index == -1
                                              && o.Bytes[0] == bytes[0]
                                              && o.Bytes[1] == bytes[1])
                                              || (o.Bytes.Count == 1
                                              && o.OpcodeParameter.Index == 1
                                              && o.Bytes[0] == bytes[0]));

                if(matched.Count() == 1)
                {
                    return matched.First();
                }
                else
                {
                    return null;
                }
            }


            if(bytes.Count == 3)
            {
                var matched = Opcodes.Where(o => (o.Bytes.Count == 3
                                               && o.OpcodeParameter.Index == -1
                                               && o.Bytes[0] == bytes[0]
                                               && o.Bytes[1] == bytes[1])
                                               && o.Bytes[2] == bytes[2]
                                               || (o.Bytes.Count == 2
                                               && o.OpcodeParameter.Index == 2
                                               && o.Bytes[0] == bytes[0]
                                               && o.Bytes[1] == bytes[1]));

                if (matched.Count() == 1)
                {
                    return matched.First();
                }
                else
                {
                    return null;
                }
            }




        }
    }
}
