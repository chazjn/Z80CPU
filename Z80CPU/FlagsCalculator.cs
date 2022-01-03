using System;
using Z80CPU.Registers;

namespace Z80CPU
{
    internal class FlagsCalculator
    {
        private readonly Z80 _z80;
        
        public FlagsCalculator(Z80 z80)
        {
            _z80 = z80;
        }

        internal void SetFlags(Register8 cloneOfA)
        {
            //if(_z80.CurrentOpcode.)

            
            
            
            
            //zero
            if (_z80.A.Value == 0)
                _z80.F.Zero = true;

            
        }
    }
}