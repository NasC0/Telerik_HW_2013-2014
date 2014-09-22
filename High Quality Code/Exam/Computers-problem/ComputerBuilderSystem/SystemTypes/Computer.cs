using System.Collections.Generic;

namespace ComputerBuilderSystem
{
    public class Computer
    {
        readonly LaptopBattery battery;

        internal void ChargeBattery(int percentage)
        {
            battery.Charge(percentage);

            VideoCard.Draw(string.Format("Battery status: {0}", battery.Percentage));
        }

        CentralProcessingUnit Cpu { get; set; }

        RandomAccessMemmory Ram { get; set; }
        
        IEnumerable<HardDiskDriveOld> HardDrives { get; set; }

        HardDiskDriveOld VideoCard { get; set; }

        public void Play(int guessNumber)
        {
            Cpu.Rand(1, 10);
            var number = Ram.LoadValue();
            if (number + 1 != guessNumber + 1)
            {
                VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                VideoCard.Draw("You win!");
            }
        }

        internal Computer(ComputerType type, CentralProcessingUnit cpu,
            RandomAccessMemmory ram, IEnumerable<HardDiskDriveOld> hardDrives,
            HardDiskDriveOld videoCard, LaptopBattery battery)
        {
            Cpu = cpu;
            Ram = ram;
            HardDrives = hardDrives;
            VideoCard = videoCard;
            if (type != ComputerType.LAPTOP && type != ComputerType.PC)
            {
                VideoCard.IsMonochrome = true;
            }

            this.battery = battery;
        }

        internal void Process(int data)
        {
            Ram.SaveValue(data);
            // TODO: Fix it
            Cpu.SquareNumber();
        }
    }
}