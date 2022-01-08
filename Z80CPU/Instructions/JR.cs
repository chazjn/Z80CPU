using System.Collections.Generic;
using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Affect.None)]
    public class JR : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.AddRange(new List<Opcode>
            {
                new Opcode("JR NZ, e", 0x20, Oprand.Any, (z80) => { return Jump(z80, !z80.F.Zero); }),
                new Opcode("JR Z, e",  0x28, Oprand.Any, (z80) => { return Jump(z80, z80.F.Zero); }),
                new Opcode("JR NC, e", 0x30, Oprand.Any, (z80) => { return Jump(z80, !z80.F.Carry); }),
                new Opcode("JR C, e",  0x38, Oprand.Any, (z80) => { return Jump(z80, z80.F.Carry); }),
                new Opcode("JR e",     0x18, Oprand.Any, (z80) => { return Jump(z80, true); }),
            });
        }

        private TStates Jump(Z80 z80, bool performJump)
        {
            if (!performJump)
                return TStates.Count(7);
            
            //TODO: test 2s-complement arithmitic
            z80.PC.Value = (ushort)(z80.PC.Value + z80.Buffer[1]);
            return TStates.Count(12);
        }
    }
}
