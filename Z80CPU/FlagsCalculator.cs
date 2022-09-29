using System;
using Z80CPU.Flags;
using Z80CPU.Registers;

namespace Z80CPU
{
    internal class FlagsCalculator
    {
        private readonly Registers.Flags _flags;
        
        public FlagsCalculator(Registers.Flags flags)
        {
            _flags = flags;
        }

        public void SetFlags(Register8 beforeA, Register8 afterA, IFlagAffects flagAffects)
        {
            //SetCarryFlag(beforeA, afterA, flagAffects.CarryAffect.Value);
            SetSubtractionFlag(beforeA, afterA, flagAffects.SubtractionAffect.Value);
            //Set(beforeA, afterA, flagAffects.ParityOrOverflowAffect.Value, 2);
            //Set(beforeA, afterA, flagAffects.HalfCarryAffect.Value, 4);
            SetZeroFlag(afterA, flagAffects.ZeroAffect.Value);
            //Set(beforeA, afterA, flagAffects.SignAffect.Value, 7);
        }

        //private void SetCarryFlag(Register8);

        private void SetSubtractionFlag(Register8 beforeA, Register8 afterA, Affect affect)
        {
            switch (affect)
            {
                case Affect.Reset:
                    _flags.Subtraction = false;
                    break;
                case Affect.Set:
                    _flags.Subtraction = true;
                    break;
                case Affect.Invert:
                    _flags.Subtraction = !_flags.Subtraction;
                    break;
                case Affect.DefaultCalculation:
                    _flags.Subtraction = true;
                    break;
                case Affect.Undefined:
                    _flags.Subtraction = GetRandomBool();
                    break;
            }
        }

        private void SetZeroFlag(Register8 afterA, Affect affect)
        {
            switch (affect)
            {
                case Affect.Reset:
                    _flags.Zero = false;
                    break;
                case Affect.Set:
                    _flags.Zero = true;
                    break;
                case Affect.Invert:
                    _flags.Zero = !_flags.Zero;
                    break;
                case Affect.DefaultCalculation:
                    _flags.Zero = afterA.Value.IsZero(); 
                    break;
                case Affect.Undefined:
                    _flags.Zero = GetRandomBool();
                    break;
            }
        } 

        private bool GetRandomBool()
        {
            var random = new Random().Next(2) == 0;
            return random;
        }
    }
}