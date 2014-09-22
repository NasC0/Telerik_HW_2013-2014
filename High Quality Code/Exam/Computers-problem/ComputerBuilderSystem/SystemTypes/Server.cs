using ComputerBuilderSystem.Contracts;

namespace ComputerBuilderSystem.SystemTypes
{
    public class Server : BaseSystem, IServerSystem
    {
        public Server(IMotherboard motherboard, ICentralProcessingUnit cpu,
                IDiskDrive diskDrive)
            : base(motherboard, cpu, diskDrive)
        {

        }

        public void Process(int data)
        {
            if (data < 0)
            {
                this.Motherboard.DrawOnVideoCard("Number to process too low.");
            }
            else if (data > this.Cpu.BitSize)
            {
                this.Motherboard.DrawOnVideoCard("Number to process too high.");
            }
            else 
            {
                int processedData = this.Cpu.SquareNumber(data);
                this.Motherboard.DrawOnVideoCard(string.Format("The processed data is: {0}", processedData));
                this.Motherboard.SaveRamValue(processedData);
            }
        }
    }
}
