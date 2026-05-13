using System;

namespace Z80CPU.Flags
{
    internal class FlagsCalculator
    {
        private readonly FlagsRegister _flags;

        public FlagsCalculator(FlagsRegister flags)
        {
            _flags = flags;
        }

        public void SetFlags(Execution execution, Instruction instruction)
        {
            var flags = instruction.Flags;
            if (flags == null) return;

            var op = flags.OperationType;
            var before = execution.Register?.PreviousValue;
            var after = execution.Register?.Value;

            Apply(flags.Sign,
                v => _flags.Sign = v,
                () => after.HasValue && ComputeSign(after.Value, op));

            Apply(flags.Zero,
                v => _flags.Zero = v,
                () => after.HasValue && after.Value == 0);

            Apply(flags.HalfCarry,
                v => _flags.HalfCarry = v,
                () => before.HasValue && after.HasValue && ComputeHalfCarry(before.Value, after.Value, op));

            Apply(flags.ParityOrOverflow,
                v => _flags.ParityOrOverflow = v,
                () => before.HasValue && after.HasValue && ComputeParityOrOverflow(before.Value, after.Value, op));

            Apply(flags.Subtraction,
                v => _flags.Subtraction = v,
                () => op == OperationType.Subtract);

            Apply(flags.Carry,
                v => _flags.Carry = v,
                () => before.HasValue && after.HasValue && ComputeCarry(before.Value, after.Value, op));
        }

        private void Apply(Affect affect, Action<bool> set, Func<bool> calculate)
        {
            switch (affect)
            {
                case Affect.Reset: set(false); break;
                case Affect.Set: set(true); break;
                case Affect.DefaultCalculation: set(calculate()); break;
                case Affect.Undefined: set(GetRandomBool()); break;
            }
        }

        private bool ComputeSign(ushort after, OperationType op)
        {
            return op == OperationType.Add16 ? (after & 0x8000) != 0 : (after & 0x80) != 0;
        }

        private bool ComputeHalfCarry(ushort before, ushort after, OperationType op)
        {
            switch (op)
            {
                case OperationType.Add:      return (after & 0x00F) < (before & 0x00F);
                case OperationType.Add16:    return (after & 0xFFF) < (before & 0xFFF);
                case OperationType.Subtract: return (after & 0x00F) > (before & 0x00F);
                default: return false;
            }
        }

        private bool ComputeParityOrOverflow(ushort before, ushort after, OperationType op)
        {
            switch (op)
            {
                case OperationType.Add:
                    var addend = (ushort)(after - before);
                    return ((before ^ ~addend) & (before ^ after) & 0x0080) != 0;
                case OperationType.Add16:
                    var addend16 = (ushort)(after - before);
                    return ((before ^ ~addend16) & (before ^ after) & 0x8000) != 0;
                case OperationType.Subtract:
                    var subtrahend = (ushort)(before - after);
                    return ((before ^ subtrahend) & (before ^ after) & 0x0080) != 0;
                case OperationType.Logic:
                    return IsEvenParity((byte)after);
                default:
                    return false;
            }
        }

        private bool ComputeCarry(ushort before, ushort after, OperationType op)
        {
            switch (op)
            {
                case OperationType.Add:
                case OperationType.Add16:    return after < before;
                case OperationType.Subtract: return after > before;
                default: return false;
            }
        }

        private bool IsEvenParity(byte value)
        {
            value ^= (byte)(value >> 4);
            value ^= (byte)(value >> 2);
            value ^= (byte)(value >> 1);
            return (value & 1) == 0;
        }

        private bool GetRandomBool() => new Random().Next(2) == 0;
    }
}
