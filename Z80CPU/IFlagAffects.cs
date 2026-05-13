using Z80CPU.Registers;

namespace Z80CPU
{
    public interface IFlagAffects
    {
        Affect? SignAffect { get; }
        Affect? ZeroAffect { get; }
        Affect? HalfCarryAffect { get; }
        Affect? ParityOrOverflowAffect { get; }
        Affect? SubtractionAffect { get; }
        Affect? CarryAffect { get; }
    }
}
