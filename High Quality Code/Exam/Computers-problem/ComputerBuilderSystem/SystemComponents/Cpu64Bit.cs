using ComputerBuilderSystem.Contracts;

namespace ComputerBuilderSystem.SystemComponents
{
    public class Cpu64Bit : BaseCpu, ICentralProcessingUnit
    {
        private const int Bit64Size = 1000;

        public Cpu64Bit(byte numberOfCores)
            : base(numberOfCores, Bit64Size)
        {

        }
    }
}
