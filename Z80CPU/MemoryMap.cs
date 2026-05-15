using System.Collections.Generic;

namespace Z80CPU
{
    public class MemoryMap : IMemory
    {
        private readonly List<(ushort Base, Memory Region)> _regions
            = new List<(ushort, Memory)>();

        public void Add(ushort baseAddress, Memory region)
            => _regions.Add((baseAddress, region));

        public byte Get(ushort address)
        {
            foreach (var (b, r) in _regions)
                if (address >= b && address < b + r.Size)
                    return r.Get((ushort)(address - b));
            return 0xFF; // open bus
        }

        public void Set(ushort address, byte value)
        {
            foreach (var (b, r) in _regions)
                if (address >= b && address < b + r.Size)
                {
                    r.Set((ushort)(address - b), value);
                    return;
                }
            // unmapped — silently ignore
        }
    }
}
