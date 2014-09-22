using ComputerBuilderSystem.Contracts;

namespace ComputerBuilderSystem.SystemComponents
{
    public class Cpu32Bit : BaseCpu, ICentralProcessingUnit
    {
        private const int Bit32Size = 500;

        public Cpu32Bit(byte numberOfCores)
            : base(numberOfCores, Bit32Size)
        {

        }
    }
}