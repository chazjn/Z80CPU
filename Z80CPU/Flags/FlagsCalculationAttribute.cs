using System;

namespace Z80CPU.Flags
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FlagsCalculationAttribute : Attribute
    {
        public OperationType OperationType { get; } = OperationType.None;
        public Affect Sign { get; set; } = Affect.NotAffected;
        public Affect Zero { get; set; } = Affect.NotAffected;
        public Affect HalfCarry { get; set; } = Affect.NotAffected;
        public Affect ParityOrOverflow { get; set; } = Affect.NotAffected;
        public Affect Subtraction { get; set; } = Affect.NotAffected;
        public Affect Carry { get; set; } = Affect.NotAffected;

        public FlagsCalculationAttribute() { }

        public FlagsCalculationAttribute(OperationType operationType)
        {
            OperationType = operationType;
        }
    }
}
