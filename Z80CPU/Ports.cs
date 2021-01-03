namespace Z80CPU
{
    public abstract class Ports
    {
        public abstract byte GetByte(ushort port);
        public abstract void SetByte(ushort port, byte value);
    }
}