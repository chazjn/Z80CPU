using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z80CPU.UnitTests
{
    public class TestPorts : Ports
    {
        public override byte GetByte(ushort port)
        {
            return (byte)new Random().Next(0, 256);
        }

        public override void SetByte(ushort port, byte value)
        {
            Console.WriteLine($"value '{value}' written to port '{port}'");
        }
    }
}
