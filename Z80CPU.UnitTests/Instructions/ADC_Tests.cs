using NUnit.Framework;

namespace Z80CPU.UnitTests.Instructions
{
    [TestFixture]
    public class ADC_Tests
    {
        // --- Instruction variants ---

        [Test]
        public void AdcA_A()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 3;
            computer.InjectInstructions(0x8F);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(6));
        }

        [Test]
        public void AdcA_B()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 3;
            computer.Z80.B.Value = 5;
            computer.InjectInstructions(0x88);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(8));
        }

        [Test]
        public void AdcA_C()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 2;
            computer.Z80.C.Value = 4;
            computer.InjectInstructions(0x89);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(6));
        }

        [Test]
        public void AdcA_D()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 1;
            computer.Z80.D.Value = 9;
            computer.InjectInstructions(0x8A);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(10));
        }

        [Test]
        public void AdcA_E()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 7;
            computer.Z80.E.Value = 8;
            computer.InjectInstructions(0x8B);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(15));
        }

        [Test]
        public void AdcA_H()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.H.Value = 20;
            computer.InjectInstructions(0x8C);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(30));
        }

        [Test]
        public void AdcA_L()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 15;
            computer.Z80.L.Value = 15;
            computer.InjectInstructions(0x8D);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(30));
        }

        [Test]
        public void AdcA_WithCarry()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 3;
            computer.Z80.B.Value = 5;
            computer.Z80.F.Carry = true;
            computer.InjectInstructions(0x88);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(9));
        }

        [Test]
        public void AdcA_Immediate()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 3;
            computer.InjectInstructions(0xCE, 0x07);
            computer.Tick(2);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(10));
        }

        [Test]
        public void AdcA_MemoryHL()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 3;
            computer.Z80.HL.Value = 0x1000;
            computer.Memory.Set(0x1000, 5);
            computer.InjectInstructions(0x8E);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(8));
        }

        // --- Flag behaviour (8-bit) ---

        [Test]
        public void ZeroFlag_SetWhenResultIsZero()
        {
            // 0xFE + 0x01 + carry(1) = 0x100 → zero
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xFE;
            computer.Z80.B.Value = 0x01;
            computer.Z80.F.Carry = true;
            computer.InjectInstructions(0x88);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Zero, Is.True);
        }

        [Test]
        public void ZeroFlag_NotSetWhenResultIsNonZero()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 5;
            computer.Z80.B.Value = 3;
            computer.InjectInstructions(0x88);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Zero, Is.False);
        }

        [Test]
        public void CarryFlag_SetOnByteOverflow()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xFF;
            computer.Z80.B.Value = 0x01;
            computer.InjectInstructions(0x88);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Carry, Is.True);
        }

        [Test]
        public void CarryFlag_SetWithCarryIn_EdgeCase()
        {
            // 0xFF + 0x00 + carry(1) = 0x100 — carry must be set
            // this fails if carry is detected as (after < before) because after==before==0xFF
            var computer = new TestComputer();
            computer.Z80.A.Value = 0xFF;
            computer.Z80.B.Value = 0x00;
            computer.Z80.F.Carry = true;
            computer.InjectInstructions(0x88);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Carry, Is.True);
        }

        [Test]
        public void CarryFlag_NotSetWithoutOverflow()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 5;
            computer.Z80.B.Value = 3;
            computer.InjectInstructions(0x88);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Carry, Is.False);
        }

        [Test]
        public void SignFlag_SetWhenBit7IsSet()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x70;
            computer.Z80.B.Value = 0x20;
            computer.InjectInstructions(0x88);
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
            computer.InjectInstructions(0x88);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Sign, Is.False);
        }

        [Test]
        public void HalfCarryFlag_SetOnNibbleOverflow()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x0F;
            computer.Z80.B.Value = 0x01;
            computer.InjectInstructions(0x88);
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
            computer.InjectInstructions(0x88);
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
            computer.InjectInstructions(0x88);
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
            computer.InjectInstructions(0x88);
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
            computer.InjectInstructions(0x88);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Subtraction, Is.False);
        }

        // --- 16-bit ADC variants ---

        [Test]
        public void AdcHL_BC()
        {
            var computer = new TestComputer();
            computer.Z80.HL.Value = 0x1000;
            computer.Z80.BC.Value = 0x0234;
            computer.InjectInstructions(0xED, 0x4A);
            computer.Tick(2);

            Assert.That(computer.Z80.HL.Value, Is.EqualTo(0x1234));
        }

        [Test]
        public void AdcHL_DE()
        {
            var computer = new TestComputer();
            computer.Z80.HL.Value = 0x1000;
            computer.Z80.DE.Value = 0x0234;
            computer.InjectInstructions(0xED, 0x5A);
            computer.Tick(2);

            Assert.That(computer.Z80.HL.Value, Is.EqualTo(0x1234));
        }

        [Test]
        public void AdcHL_HL()
        {
            var computer = new TestComputer();
            computer.Z80.HL.Value = 0x1000;
            computer.InjectInstructions(0xED, 0x6A);
            computer.Tick(2);

            Assert.That(computer.Z80.HL.Value, Is.EqualTo(0x2000));
        }

        [Test]
        public void AdcHL_SP()
        {
            var computer = new TestComputer();
            computer.Z80.HL.Value = 0x1000;
            computer.Z80.SP.Value = 0x0234;
            computer.InjectInstructions(0xED, 0x7A);
            computer.Tick(2);

            Assert.That(computer.Z80.HL.Value, Is.EqualTo(0x1234));
        }

        [Test]
        public void AdcHL_BC_WithCarry()
        {
            var computer = new TestComputer();
            computer.Z80.HL.Value = 0x1000;
            computer.Z80.BC.Value = 0x0234;
            computer.Z80.F.Carry = true;
            computer.InjectInstructions(0xED, 0x4A);
            computer.Tick(2);

            Assert.That(computer.Z80.HL.Value, Is.EqualTo(0x1235));
        }

        [Test]
        public void AdcHL_CarryFlag_Set()
        {
            var computer = new TestComputer();
            computer.Z80.HL.Value = 0xFFFF;
            computer.Z80.BC.Value = 0x0001;
            computer.InjectInstructions(0xED, 0x4A);
            computer.Tick(2);

            Assert.That(computer.Z80.F.Carry, Is.True);
        }

        [Test]
        public void AdcHL_ZeroFlag_Set()
        {
            var computer = new TestComputer();
            computer.Z80.HL.Value = 0xFFFF;
            computer.Z80.BC.Value = 0x0001;
            computer.InjectInstructions(0xED, 0x4A);
            computer.Tick(2);

            Assert.That(computer.Z80.F.Zero, Is.True);
        }
    }
}
