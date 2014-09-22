using System.Collections.Generic;
using ComputerBuilderSystem.Contracts;
using ComputerBuilderSystem.SystemComponents;
using ComputerBuilderSystem.SystemTypes;

namespace ComputerBuilderSystem.Manufacturers
{
    public class HpFactory : IManufacturer
    {
        private const int PcAndLaptopCoreNumber = 2;
        private const int ServerCoreNumber = 4;

        private const int PcRamSize = 2;
        private const int ServerRamSize = 32;
        private const int LaptopRamSize = 4;

        private const int PcAndLaptopDiskSize = 500;
        private const int ServerDiskSize = 1000;

        public IPcSystem BuildPc()
        {
            IRandomAccessMemmory ram = new RandomAccessMemmory(PcRamSize);
            IVideoCard videoCard = new ColorfulVideoCardDrawingOnConsole();
            IMotherboard motherBoard = new Motherboard(ram, videoCard);
            IDiskDrive hdd = new HardDiskDrive(PcAndLaptopDiskSize);
            ICentralProcessingUnit cpu = new Cpu32Bit(PcAndLaptopCoreNumber);

            IPcSystem resultingSystem = new PersonalComputer(motherBoard, cpu, hdd);

            return resultingSystem;
        }

        public ILaptopSystem BuildLaptop()
        {
            ILaptopBattery battery = new LaptopBattery();
            IRandomAccessMemmory ram = new RandomAccessMemmory(LaptopRamSize);
            IVideoCard videoCard = new ColorfulVideoCardDrawingOnConsole();
            IMotherboard motherBoard = new Motherboard(ram, videoCard);
            IDiskDrive hdd = new HardDiskDrive(PcAndLaptopDiskSize);
            ICentralProcessingUnit cpu = new Cpu64Bit(PcAndLaptopCoreNumber);

            ILaptopSystem resultingSystem = new Laptop(battery, motherBoard, cpu, hdd);

            return resultingSystem;
        }

        public IServerSystem BuildServer()
        {
            IRandomAccessMemmory ram = new RandomAccessMemmory(ServerRamSize);
            IVideoCard videoCard = new MonochromeVideoCardDrawingOnConsole();
            IMotherboard motherBoard = new Motherboard(ram, videoCard);
            IDiskDrive hdd = new Raid(new List<HardDiskDrive>()
            {
                new HardDiskDrive(ServerDiskSize),
                new HardDiskDrive(ServerDiskSize)
            }, ServerDiskSize);

            ICentralProcessingUnit cpu = new Cpu64Bit(ServerCoreNumber);

            IServerSystem resultingSystem = new Server(motherBoard, cpu, hdd);

            return resultingSystem;
        }
    }
}
