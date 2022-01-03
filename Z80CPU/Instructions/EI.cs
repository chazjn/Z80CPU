using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class EI : Instruction
    {
        public EI()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("EI", 0xFB, (z80) =>
                {
                    z80.InteruptsEnabled = true;
                })
            });
        }

        protected override void AddOpcodes()
        {
            throw new System.NotImplementedException();
        }
    }
}
