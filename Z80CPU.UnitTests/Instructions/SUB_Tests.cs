using NUnit.Framework;

namespace Z80CPU.UnitTests.Instructions
{
    [TestFixture]
    public class SUB_Tests
    {
        // --- Instruction variants ---

        [Test]
        public void SubA_A()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 5;
            computer.InjectInstructions(0x97);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0));
        }

        [Test]
        public void SubA_B()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.B.Value = 3;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(7));
        }

        [Test]
        public void SubA_C()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.C.Value = 4;
            computer.InjectInstructions(0x91);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(6));
        }

        [Test]
        public void SubA_D()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.D.Value = 5;
            computer.InjectInstructions(0x92);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(5));
        }

        [Test]
        public void SubA_E()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.E.Value = 6;
            computer.InjectInstructions(0x93);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(4));
        }

        [Test]
        public void SubA_H()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.H.Value = 7;
            computer.InjectInstructions(0x94);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(3));
        }

        [Test]
        public void SubA_L()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.L.Value = 8;
            computer.InjectInstructions(0x95);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(2));
        }

        [Test]
        public void SubA_MemoryHL()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.HL.Value = 0x1000;
            computer.Memory.Set(0x1000, 4);
            computer.InjectInstructions(0x96);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(6));
        }

        [Test]
        public void SubA_Immediate()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.InjectInstructions(0xD6, 0x03);
            computer.Tick(2);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(7));
        }

        [Test]
        public void SubA_IXd()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.IX.Value = 0x1000;
            computer.Memory.Set(0x1002, 4);
            computer.InjectInstructions(0xDD, 0x96, 0x02);
            computer.Tick(3);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(6));
        }

        [Test]
        public void SubA_IYd()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.IY.Value = 0x1000;
            computer.Memory.Set(0x1003, 4);
            computer.InjectInstructions(0xFD, 0x96, 0x03);
            computer.Tick(3);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(6));
        }

        // --- Flag behaviour ---

        [Test]
        public void ZeroFlag_SetWhenResultIsZero()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 5;
            computer.Z80.B.Value = 5;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Zero, Is.True);
        }

        [Test]
        public void ZeroFlag_ClearWhenResultIsNonZero()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 5;
            computer.Z80.B.Value = 3;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Zero, Is.False);
        }

        [Test]
        public void CarryFlag_SetWhenBorrow()
        {
            // A < B, so a borrow occurs
            var computer = new TestComputer();
            computer.Z80.A.Value = 5;
            computer.Z80.B.Value = 10;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Carry, Is.True);
        }

        [Test]
        public void CarryFlag_ClearWhenNoBorrow()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.B.Value = 3;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Carry, Is.False);
        }

        [Test]
        public void SignFlag_SetWhenResultIsNegative()
        {
            // 5 - 10 = -5, wraps to 0xFB, bit 7 set
            var computer = new TestComputer();
            computer.Z80.A.Value = 5;
            computer.Z80.B.Value = 10;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Sign, Is.True);
        }

        [Test]
        public void SignFlag_ClearWhenResultIsPositive()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 10;
            computer.Z80.B.Value = 3;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Sign, Is.False);
        }

        [Test]
        public void HalfCarryFlag_SetWhenBorrowFromBit4()
        {
            // lower nibble: 0x00 - 0x01 causes borrow from bit 4
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x10;
            computer.Z80.B.Value = 0x01;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.F.HalfCarry, Is.True);
        }

        [Test]
        public void HalfCarryFlag_ClearWhenNoBorrowFromBit4()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x15;
            computer.Z80.B.Value = 0x05;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.F.HalfCarry, Is.False);
        }

        [Test]
        public void OverflowFlag_SetOnSignedOverflow()
        {
            // -128 - 1 = -129, overflows to +127
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x80;
            computer.Z80.B.Value = 0x01;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.A.Value, Is.EqualTo(0x7F));
            Assert.That(computer.Z80.F.ParityOrOverflow, Is.True);
        }

        [Test]
        public void OverflowFlag_ClearWhenNoSignedOverflow()
        {
            var computer = new TestComputer();
            computer.Z80.A.Value = 0x50;
            computer.Z80.B.Value = 0x10;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.F.ParityOrOverflow, Is.False);
        }

        [Test]
        public void SubtractionFlag_AlwaysSet()
        {
            var computer = new TestComputer();
            computer.Z80.F.Subtraction = false;
            computer.Z80.A.Value = 10;
            computer.Z80.B.Value = 3;
            computer.InjectInstructions(0x90);
            computer.Tick(1);

            Assert.That(computer.Z80.F.Subtraction, Is.True);
        }
    }
}
