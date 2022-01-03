using System.Linq;

namespace Z80CPU.Instructions
{
    public class HALT : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("HALT", 0x76, z80 =>
            {
                var nop = new NOP().Opcodes.First();
                while (true)
                {
                    // excute nop
                    nop.Execute(z80);

                    //check if reset has been received

                    //check if interupt has been received
                    break;
                }
                return TStates.Count(0);
            }));
        }
    }
}
