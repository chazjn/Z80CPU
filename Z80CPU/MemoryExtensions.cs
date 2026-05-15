using Z80CPU.Registers;

namespace Z80CPU
{
    public static class MemoryExtensions
    {
        public static byte Get(this IMemory m, Register16 r)                  => m.Get(r.Value);
        public static byte Get(this IMemory m, Register16 r, sbyte o)         => m.Get((ushort)(r.Value + o));
        public static void Set(this IMemory m, Register16 r, byte v)          => m.Set(r.Value, v);
        public static void Set(this IMemory m, Register16 r, sbyte o, byte v) => m.Set((ushort)(r.Value + o), v);
    }
}
