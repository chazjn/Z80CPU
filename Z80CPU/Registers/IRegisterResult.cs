namespace Z80CPU.Registers
{
    public interface IRegisterResult
    {
        ushort PreviousValue { get; }
        ushort Value { get; }
    }
}
