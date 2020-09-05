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

        public void InjectInstructions(params byte[] bytes)
        {
            InjectInstructions(0, bytes);
        }

        public void InjectInstructions(ushort location, params byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                var memoryLocation = (ushort)(location + i);
                Memory.Set(memoryLocation, bytes[i]);
            }
        }

        public void Tick(int cycles)
        {
            for (int i = 0; i < cycles; i++)
            {
                Z80.Tick();
            }
        }
    }
}
