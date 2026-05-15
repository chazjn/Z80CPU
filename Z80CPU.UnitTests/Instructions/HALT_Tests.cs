using NUnit.Framework;

namespace Z80CPU.UnitTests.Instructions
{
    [TestFixture]
    public class HALT_Tests
    {
        [Test]
        public void Halt_SetsIsHalted()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x76);
            computer.Z80.Step();

            Assert.That(computer.Z80.IsHalted, Is.True);
        }

        [Test]
        public void Halt_FiresHaltedEvent()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x76);
            var fired = false;
            computer.Z80.Halted += (s, e) => fired = true;
            computer.Z80.Step();

            Assert.That(fired, Is.True);
        }

        [Test]
        public void Halt_PCDoesNotAdvanceDuringHaltedSteps()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x76);
            computer.Z80.Step(); // execute HALT, PC advances past 0x76 to 1
            var pcAfterHalt = computer.Z80.PC.Value;
            computer.Z80.Step(); // halted NOP
            computer.Z80.Step(); // halted NOP

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(pcAfterHalt));
        }

        [Test]
        public void Halt_EachHaltedStepAdds4TStates()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x76);
            computer.Z80.Step(); // execute HALT
            var tStatesAfterHalt = computer.Z80.TotalTStates;
            computer.Z80.Step(); // halted NOP

            Assert.That(computer.Z80.TotalTStates, Is.EqualTo(tStatesAfterHalt + 4));
        }

        [Test]
        public void Halt_INT_ExitsHalt_WhenInterruptsEnabled()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x76);
            computer.Z80.Step();
            computer.Z80.InteruptsEnabled = true;
            computer.Z80.RaiseINT();
            computer.Z80.Step();

            Assert.That(computer.Z80.IsHalted, Is.False);
        }

        [Test]
        public void Halt_INT_IM1_JumpsTo0x0038()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x76);
            computer.Z80.Step();
            computer.Z80.InteruptsEnabled = true;
            computer.Z80.RaiseINT();
            computer.Z80.Step();

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(0x0038));
        }

        [Test]
        public void Halt_INT_FiresResumedEvent()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x76);
            computer.Z80.Step();
            var fired = false;
            computer.Z80.Resumed += (s, e) => fired = true;
            computer.Z80.InteruptsEnabled = true;
            computer.Z80.RaiseINT();
            computer.Z80.Step();

            Assert.That(fired, Is.True);
        }

        [Test]
        public void Halt_INT_IgnoredWhenInterruptsDisabled()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x76);
            computer.Z80.Step();
            // InteruptsEnabled defaults to false
            computer.Z80.RaiseINT();
            computer.Z80.Step();

            Assert.That(computer.Z80.IsHalted, Is.True);
        }

        [Test]
        public void Halt_NMI_ExitsHaltRegardlessOfInterruptFlag()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x76);
            computer.Z80.Step();
            // InteruptsEnabled remains false
            computer.Z80.RaiseNMI();
            computer.Z80.Step();

            Assert.That(computer.Z80.IsHalted, Is.False);
        }

        [Test]
        public void Halt_NMI_JumpsTo0x0066()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x76);
            computer.Z80.Step();
            computer.Z80.RaiseNMI();
            computer.Z80.Step();

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(0x0066));
        }

        [Test]
        public void Halt_NMI_FiresResumedEvent()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x76);
            computer.Z80.Step();
            var fired = false;
            computer.Z80.Resumed += (s, e) => fired = true;
            computer.Z80.RaiseNMI();
            computer.Z80.Step();

            Assert.That(fired, Is.True);
        }
    }
}
