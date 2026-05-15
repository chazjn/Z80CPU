using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [FlagsCalculation(OperationType.Subtract,
        Sign = Affect.DefaultCalculation,
        Zero = Affect.DefaultCalculation,
        HalfCarry = Affect.DefaultCalculation,
        ParityOrOverflow = Affect.DefaultCalculation,
        Subtraction = Affect.Set,
        Carry = Affect.DefaultCalculation)]
    public class SUB : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("SUB A", 0x97, z80 => { z80.A.Value = (byte)(z80.A.Value - z80.A.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("SUB B", 0x90, z80 => { z80.A.Value = (byte)(z80.A.Value - z80.B.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("SUB C", 0x91, z80 => { z80.A.Value = (byte)(z80.A.Value - z80.C.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("SUB D", 0x92, z80 => { z80.A.Value = (byte)(z80.A.Value - z80.D.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("SUB E", 0x93, z80 => { z80.A.Value = (byte)(z80.A.Value - z80.E.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("SUB H", 0x94, z80 => { z80.A.Value = (byte)(z80.A.Value - z80.H.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("SUB L", 0x95, z80 => { z80.A.Value = (byte)(z80.A.Value - z80.L.Value); return Execution.Result(TStates.Count(4), z80.A); }),

                new Instruction("SUB (HL)", 0x96, z80 => { z80.A.Value = (byte)(z80.A.Value - z80.Memory.Get(z80.HL.Value)); return Execution.Result(TStates.Count(7), z80.A); }),

                new Instruction("SUB n", 0xD6, EncodingByte.Variable, z80 => { z80.A.Value = (byte)(z80.A.Value - z80.Buffer[1]); return Execution.Result(TStates.Count(7)); }),

                new Instruction("SUB (IX + d)", 0xDD, 0x96, EncodingByte.Variable, z80 =>
                {
                    var value = z80.Memory.Get(z80.IX, z80.Buffer.Displacement);
                    z80.A.Value = (byte)(z80.A.Value - value);
                    return Execution.Result(TStates.Count(19));
                }),

                new Instruction("SUB (IY + d)", 0xFD, 0x96, EncodingByte.Variable, z80 =>
                {
                    var value = z80.Memory.Get(z80.IY, z80.Buffer.Displacement);
                    z80.A.Value = (byte)(z80.A.Value - value);
                    return Execution.Result(TStates.Count(19));
                })
            });
        }
    }
}
