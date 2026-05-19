using NUnit.Framework;

namespace Z80CPU.UnitTests.Instructions
{
    [TestFixture]
    public class XOR_Tests
    {
        // --- Instruction variants ---

        [Test]
        public void XorA_A()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xAA;
            computer.InjectInstructions(0xAF);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0x00));
        }

        [Test]
        public void XorA_B()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0b10101010;
            computer.Z80.B.Value = 0b11001100;
            computer.InjectInstructions(0xA8);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0b01100110));
        }

        [Test]
        public void XorA_C()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xFF;
            computer.Z80.C.Value = 0x0F;
            computer.InjectInstructions(0xA9);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0xF0));
        }

        [Test]
        public void XorA_D()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xF0;
            computer.Z80.D.Value = 0x0F;
            computer.InjectInstructions(0xAA);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0xFF));
        }

        [Test]
        public void XorA_E()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x55;
            computer.Z80.E.Value = 0xAA;
            computer.InjectInstructions(0xAB);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0xFF));
        }

        [Test]
        public void XorA_H()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x12;
            computer.Z80.H.Value = 0x21;
            computer.InjectInstructions(0xAC);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0x33));
        }

        [Test]
        public void XorA_L()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x0F;
            computer.Z80.L.Value = 0xF0;
            computer.InjectInstructions(0xAD);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0xFF));
        }

        [Test]
        public void XorA_MemoryHL()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xB6;
            computer.Z80.HL.Value = 0x1000;
            computer.Memory.Set(0x1000, 0xD3);
            computer.InjectInstructions(0xAE);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0xB6 ^ 0xD3));
        }

        [Test]
        public void XorA_Immediate()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xAA;
            computer.InjectInstructions(0xEE, 0x55);
            computer.Tick(2);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0xFF));
        }

        [Test]
        public void XorA_IXd()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xF0;
            computer.Z80.IX.Value = 0x1000;
            computer.Memory.Set(0x1002, 0x0F);
            computer.InjectInstructions(0xDD, 0xAE, 0x02);
            computer.Tick(3);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0xFF));
        }

        [Test]
        public void XorA_IYd()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xCC;
            computer.Z80.IY.Value = 0x1000;
            computer.Memory.Set(0x1003, 0x33);
            computer.InjectInstructions(0xFD, 0xAE, 0x03);
            computer.Tick(3);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0xFF));
        }

        // --- Flag behaviour ---

        [Test]
        public void ZeroFlag_SetWhenResultIsZero()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x5A;
            computer.Z80.B.Value = 0x5A;
            computer.InjectInstructions(0xA8);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Zero, Is.True);
        }

        [Test]
        public void ZeroFlag_ClearWhenResultIsNonZero()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xFF;
            computer.Z80.B.Value = 0x0F;
            computer.InjectInstructions(0xA8);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Zero, Is.False);
        }

        [Test]
        public void SignFlag_SetWhenBit7IsSet()
        {
            // 0xFF ^ 0x7F = 0x80 — bit 7 set
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xFF;
            computer.Z80.B.Value = 0x7F;
            computer.InjectInstructions(0xA8);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0x80));
            Assert.That(computer.Z80.F.Sign, Is.True);
        }

        [Test]
        public void SignFlag_ClearWhenBit7IsClear()
        {
            // 0x40 ^ 0x01 = 0x41 — bit 7 clear
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x40;
            computer.Z80.B.Value = 0x01;
            computer.InjectInstructions(0xA8);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Sign, Is.False);
        }

        [Test]
        public void ParityFlag_SetWhenEvenNumberOfBitsSet()
        {
            // 0xF0 ^ 0x0F = 0xFF — 8 bits set, even parity
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xF0;
            computer.Z80.B.Value = 0x0F;
            computer.InjectInstructions(0xA8);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0xFF));
            Assert.That(computer.Z80.F.ParityOrOverflow, Is.True);
        }

        [Test]
        public void ParityFlag_ClearWhenOddNumberOfBitsSet()
        {
            // 0xFF ^ 0x01 = 0xFE — 7 bits set, odd parity
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xFF;
            computer.Z80.B.Value = 0x01;
            computer.InjectInstructions(0xA8);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0xFE));
            Assert.That(computer.Z80.F.ParityOrOverflow, Is.False);
        }

        [Test]
        public void HalfCarryFlag_AlwaysReset()
        {
            var computer = new TestComputer();
            computer.Z80.F.HalfCarry = true;
            computer.Z80.A.Value = 0xFF;
            computer.Z80.B.Value = 0x0F;
            computer.InjectInstructions(0xA8);
            computer.Tick(1);

            Assert.That(computer.Z80.F.HalfCarry, Is.False);
        }

        [Test]
        public void CarryFlag_AlwaysReset()
        {
            var computer = new TestComputer();
            computer.Z80.F.Carry = true;
            computer.Z80.A.Value = 0xFF;
            computer.Z80.B.Value = 0x0F;
            computer.InjectInstructions(0xA8);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Carry, Is.False);
        }

        [Test]
        public void SubtractionFlag_AlwaysReset()
        {
            var computer = new TestComputer();
            computer.Z80.F.Subtraction = true;
            computer.Z80.A.Value = 0xFF;
            computer.Z80.B.Value = 0x0F;
            computer.InjectInstructions(0xA8);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Subtraction, Is.False);
        }
    }
}
