namespace Z80CPU.Flags
{
    public enum Affect
    {
        None,
        Reset,
        Set,
        Invert,
        DefaultCalculation,
        CalculatedInOpcode,
        Undefined
    }
}
