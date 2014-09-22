using ComputerBuilderSystem.Contracts;

namespace ComputerBuilderSystem.SystemTypes
{
    public class PersonalComputer : BaseSystem, IPcSystem
    {
        public PersonalComputer(IMotherboard motherboard, ICentralProcessingUnit cpu,
                IDiskDrive diskDrive)
            :base (motherboard, cpu, diskDrive)
        {
            
        }

        public void Play(int guessNumber)
        {
            int number = this.Cpu.Rand(1, 10);

            if (number + 1 != guessNumber + 1)
            {
                this.Motherboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.Motherboard.DrawOnVideoCard("You win!");
            }
        }
    }
}
