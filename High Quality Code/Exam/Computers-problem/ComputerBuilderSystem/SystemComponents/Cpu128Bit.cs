using ComputerBuilderSystem.Contracts;

namespace ComputerBuilderSystem.SystemComponents
{
    public class Cpu128Bit : BaseCpu, ICentralProcessingUnit
    {
        private const int Bit128Size = 2000;

        public Cpu128Bit(byte numberOfCores)
            : base(numberOfCores, Bit128Size)
        {
            
        }
    }
}
