using System;
using Z80CPU.Instructions;

namespace Z80CPU.UnitTests
{
    public class TestComputer
    {
        public IMemory Memory { get; private set; }
        public Ports Ports { get; set; }
        public Z80 Z80 { get; private set; }

        public TestComputer()
        {
            var ram = new RAM(16384);
            var map = new MemoryMap();
            map.Add(0x0000, ram);
            Memory = map;
            Ports = new TestPorts();
            Z80 = new Z80(Memory, Ports);
            Z80.SP.Value = ram.Size;
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
