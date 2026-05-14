using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [FlagsCalculation(OperationType.Add,
        Sign = Affect.DefaultCalculation,
        Zero = Affect.DefaultCalculation,
        HalfCarry = Affect.DefaultCalculation,
        ParityOrOverflow = Affect.DefaultCalculation,
        Subtraction = Affect.Reset,
        Carry = Affect.DefaultCalculation)]
    public class ADD : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("ADD A, (HL)", 0x86, (z80) => {
                    z80.A.Add(z80.Memory.Get(z80.HL));
                    return Execution.Result(TStates.Count(7), z80.A);
                }),

                new Instruction("ADD A, (IX + d)", 0xDD, 0x86, EncodingByte.Variable, (z80) =>
                {
                    z80.A.Add(z80.Memory.Get(z80.IX, z80.Buffer.Displacement));
                    return Execution.Result(TStates.Count(17), z80.A);
                }),

                new Instruction("ADD A, (IY + d)", 0xFD, 0x86, EncodingByte.Variable, (z80) =>
                {
                    z80.A.Add(z80.Memory.Get(z80.IY, z80.Buffer.Displacement));
                    return Execution.Result(TStates.Count(17), z80.A);
                }),

                new Instruction("ADD A, n", 0xC6, EncodingByte.Variable, (z80) => {
                    z80.A.Add(z80.Buffer.Immediate);
                    return Execution.Result(TStates.Count(7), z80.A);
                }),
                new Instruction("ADD A, A", 0x87, (z80) => { z80.A.Add(z80.A.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADD A, B", 0x80, (z80) => { z80.A.Add(z80.B.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADD A, C", 0x81, (z80) => { z80.A.Add(z80.C.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADD A, D", 0x82, (z80) => { z80.A.Add(z80.D.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADD A, E", 0x83, (z80) => { z80.A.Add(z80.E.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADD A, H", 0x84, (z80) => { z80.A.Add(z80.H.Value); return Execution.Result(TStates.Count(4), z80.A); }),
                new Instruction("ADD A, L", 0x85, (z80) => { z80.A.Add(z80.L.Value); return Execution.Result(TStates.Count(4), z80.A); }),

                /*
                new Opcode("ADD HL, BC", 0x09, (z80) => { AddToRegister(z80, z80.HL, z80.BC.Value); }),
                new Opcode("ADD HL, DE", 0x19, (z80) => { AddToRegister(z80, z80.HL, z80.DE.Value); }),
                new Opcode("ADD HL, HL", 0x29, (z80) => { AddToRegister(z80, z80.HL, z80.HL.Value); }),
                new Opcode("ADD HL, SP", 0x39, (z80) => { AddToRegister(z80, z80.HL, z80.SP.Value); }),

                new Opcode("ADD IX, BC", 0xDD, 0x09, (z80) => { AddToRegister(z80, z80.IX, z80.BC.Value); }),
                new Opcode("ADD IX, DE", 0xDD, 0x19, (z80) => { AddToRegister(z80, z80.IX, z80.DE.Value); }),
                new Opcode("ADD IX, IX", 0xDD, 0x29, (z80) => { AddToRegister(z80, z80.IX, z80.IX.Value); }),
                new Opcode("ADD IX, SP", 0xDD, 0x39, (z80) => { AddToRegister(z80, z80.IX, z80.SP.Value); }),

                new Opcode("ADD IY, BC", 0xFD, 0x09, (z80) => { AddToRegister(z80, z80.IY, z80.BC.Value); }),
                new Opcode("ADD IY, DE", 0xFD, 0x19, (z80) => { AddToRegister(z80, z80.IY, z80.DE.Value); }),
                new Opcode("ADD IY, IY", 0xFD, 0x29, (z80) => { AddToRegister(z80, z80.IY, z80.IY.Value); }),
                new Opcode("ADD IY, SP", 0xFD, 0x39, (z80) => { AddToRegister(z80, z80.IY, z80.SP.Value); })
                */
            });
        }
    }
}
