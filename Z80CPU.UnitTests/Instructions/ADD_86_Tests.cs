using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Z80CPU.Instructions;

namespace Z80CPU.UnitTests.InstructionsB
{
    [TestFixture]
    public class ADD_86_Tests
    {
        [Test]
        public void Test1()
        {
            var instruction = new ADD_86();

            var computer = new TestComputer();
            computer.InjectInstructions(instruction);
            computer.Memory.Set(0x10, 1);
            computer.Z80.HL.Value = 0x10;
            computer.Z80.A.Value = 255;

            computer.PowerOn();

        }
    }
}
