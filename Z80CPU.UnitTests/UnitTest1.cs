using System;
using NUnit.Framework;
using Z80CPU;

namespace Z80CPU.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var zxSpectrum = new Computer();
            zxSpectrum.PowerOn();

        }
    }
}
