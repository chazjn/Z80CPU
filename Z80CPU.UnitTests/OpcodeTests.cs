using System;
using NUnit.Framework;
using Z80CPU;

namespace Z80CPU.UnitTests
{
    [TestFixture]
    public class OpcodeTests
    {
        [TestCase(new byte[] { 0x86 })]
        [TestCase(new byte[] { 0xDD })]
        public void IsMatch_MatchedBytes_ReturnsTrue(byte[] bytes)
        {
            var instructionSet = new InstructionSet();
            var buffer = new InstructionBuffer();
            foreach (var b in bytes) buffer.Add(b);

            var candidates = instructionSet.GetCandidates(buffer);

            Assert.IsTrue(candidates.Count > 0);
        }
    }
}
