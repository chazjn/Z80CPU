using Z80CPU.Instructions;

namespace Z80CPU.UnitTests
{
    public class TestComputer
    {
        public Memory Memory { get; private set; }
        public Z80 Z80 { get; private set; }

        public TestComputer()
        {
            Memory = new RAM(16384);
            Z80 = new Z80(Memory);
        }

        public void InjectInstructions(params Instruction_OLD[] instructions)
        {
            InjectInstructions(0, instructions);
        }

        public void InjectInstructions(ushort location, params Instruction_OLD[] instructions)
        {
            foreach(var instruction in instructions)
            {
               foreach(var rawByte in instruction.RawBytes)
               {
                    Memory.Set(location, rawByte);
                    location++;
               }
            }
        }

        public void PowerOn()
        {
            Z80.Boot();
        }
    }
}
