using ComputerBuilderClasses.Contracts;

namespace ComputerBuilderClasses.SystemTypes
{
    public class Server : BaseSystem, IServerSystem
    {
        public Server(IMotherboard motherboard, ICentralProcessingUnit cpu, IDiskDrive diskDrive)
            : base(motherboard, cpu, diskDrive)
        {
        }

        public void Process(int data)
        {
            if (data < 0)
            {
                this.Motherboard.DrawOnVideoCard("Number too low.");
            }
            else if (data > this.Cpu.BitSize)
            {
                this.Motherboard.DrawOnVideoCard("Number too high.");
            }
            else 
            {
                int processedData = this.Cpu.SquareNumber(data);
                this.Motherboard.DrawOnVideoCard(string.Format("Square of {0} is {1}", data, processedData));
                this.Motherboard.SaveRamValue(processedData);
            }
        }
    }
}
