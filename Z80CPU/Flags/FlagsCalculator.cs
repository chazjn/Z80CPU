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
            var op = instruction.OperationType;
            var before = execution.Register?.PreviousValue;
            var after = execution.Register?.Value;

            Apply(instruction.SignAffect,
                v => _flags.Sign = v, () => _flags.Sign,
                () => after.HasValue && ComputeSign(after.Value, op));

            Apply(instruction.ZeroAffect,
                v => _flags.Zero = v, () => _flags.Zero,
                () => after.HasValue && after.Value == 0);

            Apply(instruction.HalfCarryAffect,
                v => _flags.HalfCarry = v, () => _flags.HalfCarry,
                () => before.HasValue && after.HasValue && ComputeHalfCarry(before.Value, after.Value, op));

            Apply(instruction.ParityOrOverflowAffect,
                v => _flags.ParityOrOverflow = v, () => _flags.ParityOrOverflow,
                () => before.HasValue && after.HasValue && ComputeParityOrOverflow(before.Value, after.Value, op));

            Apply(instruction.SubtractionAffect,
                v => _flags.Subtraction = v, () => _flags.Subtraction,
                () => op == OperationType.Subtract);

            Apply(instruction.CarryAffect,
                v => _flags.Carry = v, () => _flags.Carry,
                () => before.HasValue && after.HasValue && ComputeCarry(before.Value, after.Value, op));
        }

        private void Apply(Affect? affect, Action<bool> set, Func<bool> get, Func<bool> calculate)
        {
            switch (affect)
            {
                case Affect.Reset: set(false); break;
                case Affect.Set: set(true); break;
                case Affect.Invert: set(!get()); break;
                case Affect.DefaultCalculation: set(calculate()); break;
                case Affect.Undefined: set(GetRandomBool()); break;
            }
        }

        private bool ComputeSign(ushort after, OperationType? op)
        {
            return op == OperationType.Add16 ? (after & 0x8000) != 0 : (after & 0x80) != 0;
        }

        private bool ComputeHalfCarry(ushort before, ushort after, OperationType? op)
        {
            switch (op)
            {
                case OperationType.Add:      return (after & 0x00F) < (before & 0x00F);
                case OperationType.Add16:    return (after & 0xFFF) < (before & 0xFFF);
                case OperationType.Subtract: return (after & 0x00F) > (before & 0x00F);
                default: return false;
            }
        }

        private bool ComputeParityOrOverflow(ushort before, ushort after, OperationType? op)
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

        private bool ComputeCarry(ushort before, ushort after, OperationType? op)
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
