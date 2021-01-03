using Z80CPU.ROMS;

namespace Z80CPU
{
    public class ROM : Memory
    {
        public ROM(ushort length) : base(length)
        {
        }

        public ROM(IData data) : base(data.Length)
        {
            Bytes = data.GetBytes();
        }

        public override void Set(int index, byte value)
        {
            //do nothing you can't write to ROM
        }
    }
}
