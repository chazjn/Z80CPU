using System.Linq;

namespace Z80CPU.Instructions
{
    public class HALT : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("HALT", 0x76, z80 =>
            {
                var nop = new NOP().Instructions.First();
                while (true)
                {
                    // excute nop
                    nop.Execute(z80);

                    //check if reset has been received

                    //check if interupt has been received
                    break;
                }
                return Execution.Result(TStates.Count(0));
            }));
        }
    }
}
