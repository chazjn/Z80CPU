using Z80CPU.Flags;

namespace Z80CPU.Instructions
{
    [Flag(Affect.None)]
    public class EXX : Instruction
    {
        protected override void AddOpcodes()
        {
            Opcodes.Add(new Opcode("EXX", 0xD9, (z80) =>            
            {
                var bc = z80.BC.Value;
                var de = z80.DE.Value;
                var hl = z80.HL.Value;

                z80.BC.Value = z80.BC_.Value;
                z80.DE.Value = z80.DE_.Value;
                z80.HL.Value = z80.HL_.Value;

                z80.BC_.Value = bc;
                z80.DE_.Value = de;
                z80.HL_.Value = hl;

                return TStates.Count(4);
            }));
        }
    }
}
