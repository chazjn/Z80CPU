namespace Z80CPU
{
    public class MemoryManager : Memory
    {
        private readonly ROM _rom;
        private readonly RAM _ram;

        public MemoryManager(ROM rom, RAM ram) : base((ushort)(rom.Size + ram.Size))
        {
            _rom = rom;
            _ram = ram;
        }

        public override byte Get(int index)
        {
            //We are setting the ROM to start from 0 and the RAM starts after the end of the RAM
            if (index > _rom.Size - 1)
            {
                return _ram.Get((ushort)(_rom.Size + index));
            }
            else
            {
                return _rom.Get(index);
            }
        }

        public override void Set(int index, byte value)
        {
            //don't do anthing if index inside ROM range
            if (index > _rom.Size - 1)
            {
                _ram.Set(index, value);
            }
        }
    }
}
