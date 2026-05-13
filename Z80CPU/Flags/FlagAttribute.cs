using System;

namespace Z80CPU.Flags
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class FlagAttribute : Attribute
    {
        public Name Name { get; }
        public Affect Affect { get; }

        public FlagAttribute(Name name, Affect affect)
        {
            Name = name;
            Affect = affect;
        }

        public FlagAttribute(Affect affect)
        {
            Affect = affect;
        }
    }
}
