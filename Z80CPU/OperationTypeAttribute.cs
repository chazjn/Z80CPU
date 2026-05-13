using System;

namespace Z80CPU
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class OperationTypeAttribute : Attribute
    {
        public OperationType OperationType { get; }

        public OperationTypeAttribute(OperationType operationType)
        {
            OperationType = operationType;
        }
    }
}
