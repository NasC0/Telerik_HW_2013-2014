using System.Collections.Generic;
using ComputerBuilderClasses.Contracts;
using ComputerBuilderClasses.SystemComponents;
using ComputerBuilderClasses.SystemTypes;

namespace ComputerBuilderClasses.Manufacturers
{
    public class LenovoFactory : IManufacturer
    {
        private const int CpuCoreNumber = 2;

        private const int PcRamSize = 4;
        private const int ServerRamSize = 8;
        private const int LaptopRamSize = 16;

        private const int PcDiskSize = 2000;
        private const int ServerDiskSize = 500;
        private const int LaptopDiskSize = 1000;

        public IPcSystem BuildPc()
        {
            IRandomAccessMemmory ram = new RandomAccessMemmory(PcRamSize);
            IVideoCard videoCard = new MonochromeVideoCardDrawingOnConsole();
            IMotherboard motherBoard = new Motherboard(ram, videoCard);
            IDiskDrive hdd = new HardDiskDrive(PcDiskSize);
            ICentralProcessingUnit cpu = new Cpu32Bit(CpuCoreNumber);

            IPcSystem resultingSystem = new PersonalComputer(motherBoard, cpu, hdd);

            return resultingSystem;
        }

        public ILaptopSystem BuildLaptop()
        {
            ILaptopBattery battery = new LaptopBattery();
            IRandomAccessMemmory ram = new RandomAccessMemmory(LaptopRamSize);
            IVideoCard videoCard = new ColorfulVideoCardDrawingOnConsole();
            IMotherboard motherBoard = new Motherboard(ram, videoCard);
            IDiskDrive hdd = new HardDiskDrive(LaptopDiskSize);
            ICentralProcessingUnit cpu = new Cpu64Bit(CpuCoreNumber);

            ILaptopSystem resultingSystem = new Laptop(battery, motherBoard, cpu, hdd);

            return resultingSystem;
        }

        public IServerSystem BuildServer()
        {
            IRandomAccessMemmory ram = new RandomAccessMemmory(ServerRamSize);
            IVideoCard videoCard = new MonochromeVideoCardDrawingOnConsole();
            IMotherboard motherBoard = new Motherboard(ram, videoCard);
            IDiskDrive hdd = new Raid(
                new List<HardDiskDrive>()
                {
                    new HardDiskDrive(ServerDiskSize),
                    new HardDiskDrive(ServerDiskSize)
                }, 
                ServerDiskSize);

            ICentralProcessingUnit cpu = new Cpu128Bit(CpuCoreNumber);

            IServerSystem resultingSystem = new Server(motherBoard, cpu, hdd);

            return resultingSystem;
        }
    }
}
