using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class INC16 : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("INC BC", 0x03, (z80) => { z80.BC.Increment(); return Execution.Result(TStates.Count(6)); }),
                new Instruction("INC DE", 0x13, (z80) => { z80.DE.Increment(); return Execution.Result(TStates.Count(6)); }),
                new Instruction("INC HL", 0x23, (z80) => { z80.HL.Increment(); return Execution.Result(TStates.Count(6)); }),
                new Instruction("INC SP", 0x33, (z80) => { z80.SP.Increment(); return Execution.Result(TStates.Count(6)); }),

                new Instruction("INC (HL)", 0x34, (z80) =>
                {
                    var value = z80.Memory.Get(z80.HL);
                    value++;
                    z80.Memory.Set(z80.HL, value);
                    return Execution.Result(TStates.Count(11));
                }),

                new Instruction("INC (IX + d)", 0xDD, 0x34, EncodingByte.Variable, (z80) =>
                {
                    var index = (ushort)(z80.IX.Value + z80.Buffer[2]);
                    var value = z80.Memory.Get(index);
                    value++;
                    z80.Memory.Set(index, value);
                    return Execution.Result(TStates.Count(23));
                }),

                new Instruction("INC (IY + d)", 0xFD, 0x34, EncodingByte.Variable, (z80) =>
                {
                    var index = (ushort)(z80.IY.Value + z80.Buffer[2]);
                    var value = z80.Memory.Get(index);
                    value++;
                    z80.Memory.Set(index, value);
                    return Execution.Result(TStates.Count(23));
                }),

                new Instruction("INC IX", 0xDD, 0x23, (z80) => { z80.IX.Increment(); return Execution.Result(TStates.Count(10)); }),
                new Instruction("INC IY", 0xFD, 0x23, (z80) => { z80.IY.Increment(); return Execution.Result(TStates.Count(10)); }),
            });
        }
    }
}
