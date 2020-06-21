namespace Z80CPU.Instructions
{
    public class ADD_86 : Instruction_OLD
    {
        public ADD_86() : base("ADD A, (HL)", 0x86)
        {
        }

        public override void Execute(Z80 z80)
        {
            var hl = z80.Memory.Get(z80.HL.Value);
            var a = z80.A.Value;
            var result = hl + a;

            z80.A.Value = (byte)result;

            //set flags
            z80.F.SetZero(z80.A.Value);
            z80.F.SetSubtraction(false);


        }
    }
}