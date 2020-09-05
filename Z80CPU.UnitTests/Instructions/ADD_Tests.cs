using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace Z80CPU.UnitTests.Instructions
{
    
    [TestFixture]
    public class ADD_Tests
    {
        [Test]
        public void Test1()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x3E, 0x10, 0xC6, 0x01);
            computer.Tick(4);

            Assert.IsTrue(computer.Z80.A.Value == 0x11);

        }
    }
}
