using Z80CPU.Registers;

namespace Z80CPU
{
    public class Execution
    {
        public TStates TStates { get; }
        public IRegisterResult Register { get; }

        public static Execution Result(TStates tStates, IRegisterResult register) =>
            new Execution(tStates, register);

        public static Execution Result(TStates tStates) =>
            new Execution(tStates, null);

        private Execution(TStates tStates, IRegisterResult register)
        {
            TStates = tStates;
            Register = register;
        }
    }
}
