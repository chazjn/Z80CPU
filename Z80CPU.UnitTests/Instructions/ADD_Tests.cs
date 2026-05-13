using NUnit.Framework;

namespace Z80CPU.UnitTests.Instructions
{
    [TestFixture]
    public class ADD_Tests
    {
        // --- Instruction variants ---

        [Test]
        public void AddA_A()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 3;
            computer.InjectInstructions(0x87);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(6));
        }

        [Test]
        public void AddA_B()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 3;
            computer.Z80.B.Value = 5;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(8));
        }

        [Test]
        public void AddA_C()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 2;
            computer.Z80.C.Value = 4;
            computer.InjectInstructions(0x81);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(6));
        }

        [Test]
        public void AddA_D()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 1;
            computer.Z80.D.Value = 9;
            computer.InjectInstructions(0x82);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(10));
        }

        [Test]
        public void AddA_E()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 7;
            computer.Z80.E.Value = 8;
            computer.InjectInstructions(0x83);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(15));
        }

        [Test]
        public void AddA_H()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.H.Value = 20;
            computer.InjectInstructions(0x84);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(30));
        }

        [Test]
        public void AddA_L()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 15;
            computer.Z80.L.Value = 15;
            computer.InjectInstructions(0x85);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(30));
        }

        [Test]
        public void AddA_Immediate()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 3;
            computer.InjectInstructions(0xC6, 0x07);
            computer.Tick(2);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(10));
        }

        [Test]
        public void AddA_MemoryHL()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 3;
            computer.Z80.HL.Value = 0x1000;
            computer.Memory.Set(0x1000, 5);
            computer.InjectInstructions(0x86);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(8));
        }

        // --- Flag behaviour ---

        [Test]
        public void ZeroFlag_SetWhenResultIsZero()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xFF;
            computer.Z80.B.Value = 0x01;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Zero, Is.True);
        }

        [Test]
        public void ZeroFlag_NotSetWhenResultIsNonZero()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 5;
            computer.Z80.B.Value = 3;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Zero, Is.False);
        }

        [Test]
        public void CarryFlag_SetOnByteOverflow()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xFF;
            computer.Z80.B.Value = 0x01;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Carry, Is.True);
        }

        [Test]
        public void CarryFlag_NotSetWithoutOverflow()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 5;
            computer.Z80.B.Value = 3;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Carry, Is.False);
        }

        [Test]
        public void SignFlag_SetWhenBit7IsSet()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x70;
            computer.Z80.B.Value = 0x20;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0x90));
            Assert.That(computer.Z80.F.Sign, Is.True);
        }

        [Test]
        public void SignFlag_NotSetWhenBit7IsClear()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 5;
            computer.Z80.B.Value = 3;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Sign, Is.False);
        }

        [Test]
        public void HalfCarryFlag_SetOnNibbleOverflow()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x0F;
            computer.Z80.B.Value = 0x01;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0x10));
            Assert.That(computer.Z80.F.HalfCarry, Is.True);
        }

        [Test]
        public void HalfCarryFlag_NotSetWithoutNibbleOverflow()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x10;
            computer.Z80.B.Value = 0x10;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.F.HalfCarry, Is.False);
        }

        [Test]
        public void OverflowFlag_SetOnSignedOverflow()
        {
            // 127 + 1 = 128, which wraps to -128 in signed arithmetic
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x7F;
            computer.Z80.B.Value = 0x01;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0x80));
            Assert.That(computer.Z80.F.ParityOrOverflow, Is.True);
        }

        [Test]
        public void OverflowFlag_NotSetWithoutSignedOverflow()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x50;
            computer.Z80.B.Value = 0x10;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.F.ParityOrOverflow, Is.False);
        }

        [Test]
        public void SubtractionFlag_AlwaysReset()
        {
            var computer = new TestComputer();
            computer.Z80.F.Subtraction = true;
            computer.Z80.A.Value = 5;
            computer.Z80.B.Value = 3;
            computer.InjectInstructions(0x80);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Subtraction, Is.False);
        }
    }
}
