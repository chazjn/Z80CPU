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
            var rawSum = execution.Register?.RawSum;

            Apply(flags.Sign,
                v => _flags.Sign = v,
                () => after.HasValue && ComputeSign(after.Value, op));

            Apply(flags.Zero,
                v => _flags.Zero = v,
                () => after.HasValue && after.Value == 0);

            Apply(flags.HalfCarry,
                v => _flags.HalfCarry = v,
                () => before.HasValue && after.HasValue && ComputeHalfCarry(before.Value, after.Value, rawSum.GetValueOrDefault(), op));

            Apply(flags.ParityOrOverflow,
                v => _flags.ParityOrOverflow = v,
                () => before.HasValue && after.HasValue && ComputeParityOrOverflow(before.Value, after.Value, rawSum.GetValueOrDefault(), op));

            Apply(flags.Subtraction,
                v => _flags.Subtraction = v,
                () => op == OperationType.Subtract);

            Apply(flags.Carry,
                v => _flags.Carry = v,
                () => after.HasValue && ComputeCarry(before.GetValueOrDefault(), after.Value, rawSum.GetValueOrDefault(), op));
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
            return (op == OperationType.Add16 || op == OperationType.AddWithCarry16)
                ? (after & 0x8000) != 0
                : (after & 0x80) != 0;
        }

        private bool ComputeHalfCarry(ushort before, ushort after, int rawSum, OperationType op)
        {
            switch (op)
            {
                case OperationType.Add:
                case OperationType.AddWithCarry:
                    return ((before ^ (rawSum - before) ^ rawSum) & 0x10) != 0;
                case OperationType.Add16:
                case OperationType.AddWithCarry16:
                    return ((before ^ (rawSum - before) ^ rawSum) & 0x1000) != 0;
                case OperationType.Subtract:
                    return (after & 0x00F) > (before & 0x00F);
                default: return false;
            }
        }

        private bool ComputeParityOrOverflow(ushort before, ushort after, int rawSum, OperationType op)
        {
            switch (op)
            {
                case OperationType.Add:
                case OperationType.AddWithCarry:
                    return (~(before ^ (rawSum - before)) & (before ^ rawSum) & 0x0080) != 0;
                case OperationType.Add16:
                case OperationType.AddWithCarry16:
                    return (~(before ^ (rawSum - before)) & (before ^ rawSum) & 0x8000) != 0;
                case OperationType.Subtract:
                    var subtrahend = (ushort)(before - after);
                    return ((before ^ subtrahend) & (before ^ after) & 0x0080) != 0;
                case OperationType.Logic:
                    return IsEvenParity((byte)after);
                default:
                    return false;
            }
        }

        private bool ComputeCarry(ushort before, ushort after, int rawSum, OperationType op)
        {
            switch (op)
            {
                case OperationType.Add:
                case OperationType.AddWithCarry:
                    return rawSum > 0xFF;
                case OperationType.Add16:
                case OperationType.AddWithCarry16:
                    return rawSum > 0xFFFF;
                case OperationType.Subtract:
                    return after > before;
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
