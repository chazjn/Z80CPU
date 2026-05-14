using System.Collections.Generic;

namespace Z80CPU.Instructions
{
    public class JR : Mnemonic
    {
        protected override void AddInstructions()
        {
            Instructions.AddRange(new List<Instruction>
            {
                new Instruction("JR NZ, e", 0x20, EncodingByte.Variable, (z80) => { return Jump(z80, !z80.F.Zero); }),
                new Instruction("JR Z, e",  0x28, EncodingByte.Variable, (z80) => { return Jump(z80, z80.F.Zero); }),
                new Instruction("JR NC, e", 0x30, EncodingByte.Variable, (z80) => { return Jump(z80, !z80.F.Carry); }),
                new Instruction("JR C, e",  0x38, EncodingByte.Variable, (z80) => { return Jump(z80, z80.F.Carry); }),
                new Instruction("JR e",     0x18, EncodingByte.Variable, (z80) => { return Jump(z80, true); }),
            });
        }

        private Execution Jump(Z80 z80, bool performJump)
        {
            if (!performJump)
                return Execution.Result(TStates.Count(7));

            z80.PC.Value = (ushort)(z80.PC.Value + z80.Buffer.Offset);
            return Execution.Result(TStates.Count(12));
        }
    }
}
