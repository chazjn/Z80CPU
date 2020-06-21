using Z80CPU.ROMS;
using Z80CPU.Instructions;

namespace Z80CPU
{
    public class Computer
    {
        public Memory Memory { get; private set; }
        public Z80 Z80 { get; private set; }

        public Computer()
        {
            var rom = new ROM(new ZXSpectrum48KROM());
            var ram = new RAM(49152);

            Memory = new MemoryManager(rom, ram);
            Z80 = new Z80(Memory);
        }

        public void PowerOn()
        {
            Z80.Boot();
        }
    }
}
