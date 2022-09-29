using System;
using System.Collections.Generic;
using System.Text;

namespace Z80CPU
{
    public class OpcodeBuilder
    {
        private Opcode _opcode;

        public Opcode Build() => _opcode;

        public void CreateNew()
        {
            _opcode = new Opcode();
        }
        
        public OpcodeBuilder Name(string name)
        {
            _opcode.Name = name;
            return this;
        }

        //public OpcodeBuilder HasOprands()


    }
}
