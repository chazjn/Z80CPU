using System.Linq;

namespace Z80CPU.Instructions
{
    public class HALT : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.Add(new Instruction("HALT", 0x76, z80 =>
            {
                z80.Halt();
                return new NOP().Instructions.First().Execute(z80);
            }));
        }
    }
}
