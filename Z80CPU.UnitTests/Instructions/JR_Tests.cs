using NUnit.Framework;

namespace Z80CPU.UnitTests.Instructions
{
    [TestFixture]
    public class JR_Tests
    {
        [Test]
        public void Jr_UnconditionalForwardJump()
        {
            var computer = new TestComputer();
            computer.InjectInstructions(0x18, 0x05);
            computer.Tick(2);

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(7)); // 2 + 5
        }

        [Test]
        public void Jr_UnconditionalBackwardJump()
        {
            const ushort address = 0x10;
            var computer = new TestComputer();
            computer.Z80.PC.Value = address;
            computer.InjectInstructions(address, 0x18, 0xFE); // offset = -2
            computer.Tick(2);

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(0x10)); // 0x12 + (-2)
        }

        [Test]
        public void Jr_NZ_JumpTaken_WhenZeroFlagClear()
        {
            var computer = new TestComputer();
            computer.Z80.F.Zero = false;
            computer.InjectInstructions(0x20, 0x03);
            computer.Tick(2);

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(5)); // 2 + 3
        }

        [Test]
        public void Jr_NZ_JumpNotTaken_WhenZeroFlagSet()
        {
            var computer = new TestComputer();
            computer.Z80.F.Zero = true;
            computer.InjectInstructions(0x20, 0x03);
            computer.Tick(2);

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(2));
        }

        [Test]
        public void Jr_Z_JumpTaken_WhenZeroFlagSet()
        {
            var computer = new TestComputer();
            computer.Z80.F.Zero = true;
            computer.InjectInstructions(0x28, 0x03);
            computer.Tick(2);

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(5)); // 2 + 3
        }

        [Test]
        public void Jr_Z_JumpNotTaken_WhenZeroFlagClear()
        {
            var computer = new TestComputer();
            computer.Z80.F.Zero = false;
            computer.InjectInstructions(0x28, 0x03);
            computer.Tick(2);

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(2));
        }

        [Test]
        public void Jr_NC_JumpTaken_WhenCarryFlagClear()
        {
            var computer = new TestComputer();
            computer.Z80.F.Carry = false;
            computer.InjectInstructions(0x30, 0x03);
            computer.Tick(2);

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(5)); // 2 + 3
        }

        [Test]
        public void Jr_NC_JumpNotTaken_WhenCarryFlagSet()
        {
            var computer = new TestComputer();
            computer.Z80.F.Carry = true;
            computer.InjectInstructions(0x30, 0x03);
            computer.Tick(2);

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(2));
        }

        [Test]
        public void Jr_C_JumpTaken_WhenCarryFlagSet()
        {
            var computer = new TestComputer();
            computer.Z80.F.Carry = true;
            computer.InjectInstructions(0x38, 0x03);
            computer.Tick(2);

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(5)); // 2 + 3
        }

        [Test]
        public void Jr_C_JumpNotTaken_WhenCarryFlagClear()
        {
            var computer = new TestComputer();
            computer.Z80.F.Carry = false;
            computer.InjectInstructions(0x38, 0x03);
            computer.Tick(2);

            Assert.That(computer.Z80.PC.Value, Is.EqualTo(2));
        }
    }
}
