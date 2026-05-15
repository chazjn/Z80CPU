using System;
using Z80CPU.Flags;
using Z80CPU.Registers;

namespace Z80CPU
{
    public interface IZ80
    {
        // Control
        Execution Step();
        void Halt();
        void Reset();
        void RaiseINT();
        void RaiseNMI();

        // Timing
        bool ThrottleEnabled { get; set; }
        int ClockFrequency { get; set; }
        long TotalTStates { get; }
        TimeSpan ElapsedTime { get; }

        // State
        bool IsHalted { get; }
        bool InteruptsEnabled { get; }
        InterruptMode InteruptMode { get; }

        // Events
        event EventHandler Halted;
        event EventHandler Resumed;

        // Registers
        Register8 A { get; }
        Register8 B { get; }
        Register8 C { get; }
        Register8 D { get; }
        Register8 E { get; }
        Register8 H { get; }
        Register8 L { get; }
        FlagsRegister F { get; }
        Register16 AF { get; }
        Register16 BC { get; }
        Register16 DE { get; }
        Register16 HL { get; }
        Register16 IX { get; }
        Register16 IY { get; }
        Register16 PC { get; }
        Register16 SP { get; }
    }
}
