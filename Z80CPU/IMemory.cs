namespace Z80CPU
{
    public interface IMemory
    {
        byte Get(ushort address);
        void Set(ushort address, byte value);
    }
}
