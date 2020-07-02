using System.Collections.Generic;

namespace Z80CPU
{
    public class OpcodeByte
    {
        public byte Value { get; }
        public List<byte> AlternativeValues { get; }

        public bool HasAlternatives
        {
            get
            {
                if (AlternativeValues.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public OpcodeByte(byte value, params byte[] alterativeValues)
        {
            Value = value;
            AlternativeValues = new List<byte>(alterativeValues);
        }

        public OpcodeByte(byte start, byte end)
        {

        }
    }
}
