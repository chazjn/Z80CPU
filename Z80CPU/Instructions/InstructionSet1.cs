using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU.Instructions
{
    public class InstructionSet1
    {
        protected List<Instruction_OLD> _instructions { get; set; } = new List<Instruction_OLD>();
        public IReadOnlyList<Instruction_OLD> Instructions { get { return _instructions; } }

        public InstructionSet1()
        {
            _instructions.AddRange(new Instruction_OLD[]
            {
                new ADD_86(),
                new ADD_DD(),
                new ADD_FD(),

                new BIT_DD(),

                new DI(),
                new EXX(),

                new XOR_AF()
            });
        } 

        public IList<Instruction_OLD> Filter(List<byte> opcodes)
        {
            var list = new List<Instruction_OLD>();
            list.AddRange(Instructions);

            for (int i = 0; i < opcodes.Count; i++)
            {
                list.RemoveAll(x => x.Opcodes[i] != opcodes[i]);                
            }

            return list;
        }
    }
}
