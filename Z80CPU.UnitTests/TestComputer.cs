using System;
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

        public void InjectInstructions(params Z80CPU.Opcode[] opcodes)
        {
            InjectInstructions(0, opcodes);
        }

        public void InjectInstructions(ushort location, params Z80CPU.Opcode[] opcodes)
        {
            foreach(var opcode in opcodes)
            {
                throw new NotImplementedException();
                /*
               foreach(var rawByte in instruction.RawBytes)
               {
                    Memory.Set(location, rawByte);
                    location++;
               }
               */
            }
        }

        public void PowerOn()
        {
            Z80.Boot();
        }
    }
}
