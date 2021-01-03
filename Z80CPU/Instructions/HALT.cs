using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z80CPU.Instructions
{
    public class HALT : Instruction
    {
        public HALT()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("HALT", 0x76, z80 =>
                {
                    var nop = new NOP().Opcodes.First();
                    while (true)
                    {
                        // excute nop
                        nop.Execute(z80);

                        //check if reset has been received

                        //check if interupt has been received
	                }
                })
            });
        }
    }
}
