using System.Collections.Generic;
using Z80CPU.Registers;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Name.Sign, Affect.DefaultCalculation)]
    [Flag(Name.Zero, Affect.DefaultCalculation)]
    [Flag(Name.HalfCarry, Affect.DefaultCalculation)]
    [Flag(Name.ParityOrOverflow, Affect.DefaultCalculation)]
    [Flag(Name.Subraction, Affect.Reset)]
    public class INC : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("INC A", 0x3C, (z80) => { z80.A.Increment(); return TStates.Count(4); }),
                new Instruction("INC B", 0x04, (z80) => { z80.B.Increment(); return TStates.Count(4); }),
                new Instruction("INC C", 0x0C, (z80) => { z80.C.Increment(); return TStates.Count(4); }),
                new Instruction("INC D", 0x14, (z80) => { z80.D.Increment(); return TStates.Count(4); }),
                new Instruction("INC E", 0x1C, (z80) => { z80.E.Increment(); return TStates.Count(4); }),
                new Instruction("INC H", 0x24, (z80) => { z80.H.Increment(); return TStates.Count(4); }),
                new Instruction("INC L", 0x2C, (z80) => { z80.L.Increment(); return TStates.Count(4); }),

                new Instruction("INC BC", 0x03, (z80) => { z80.BC.Increment(); return TStates.Count(11); }).SetAllFlagsAffectToNone(),
                new Instruction("INC DE", 0x13, (z80) => { z80.DE.Increment(); return TStates.Count(11); }).SetAllFlagsAffectToNone(),
                new Instruction("INC HL", 0x23, (z80) => { z80.HL.Increment(); return TStates.Count(11); }).SetAllFlagsAffectToNone(),
                new Instruction("INC SP", 0x33, (z80) => { z80.SP.Increment(); return TStates.Count(11); }).SetAllFlagsAffectToNone(),

                new Instruction("INC (HL)", 0x34, (z80) => 
                {
                    var value = z80.Memory.Get(z80.HL);
                    z80.Memory.Set(z80.HL, ++value);
                    return TStates.Count(11);
                }).SetAllFlagsAffectToNone(),

                new Instruction("INC (IX + d)", 0xDD, 0x34, (z80) =>
                {
                    var offset = z80.GetByte();
                    var index = (ushort)(z80.IX.Value + offset);
                    var value = z80.Memory.Get(index);
                    z80.Memory.Set(index, ++value);
                    return TStates.Count(23);
                }).SetAllFlagsAffectToNone(),

                new Instruction("INC (IY + d)", 0xFD, 0x34, (z80) =>
                {
                    var offset = z80.GetByte();
                    var index = (ushort)(z80.IY.Value + offset);
                    var value = z80.Memory.Get(index);
                    z80.Memory.Set(index, ++value);
                    return TStates.Count(23);
                }).SetAllFlagsAffectToNone(),

                new Instruction("INC IX", 0xDD, 0x23, (z80) => { z80.IX.Increment(); return TStates.Count(10); }).SetAllFlagsAffectToNone(),
                new Instruction("INC IY", 0xFD, 0x23, (z80) => { z80.IY.Increment(); return TStates.Count(10); }).SetAllFlagsAffectToNone(),
            });
        }
    }
}
