namespace Z80CPU.ROMS
{
    public interface IData
    {
        ushort Length { get; }
        byte[] GetBytes();
    }
}
