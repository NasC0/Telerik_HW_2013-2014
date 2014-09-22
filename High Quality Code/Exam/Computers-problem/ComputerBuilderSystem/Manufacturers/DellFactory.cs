using System.Collections.Generic;
using ComputerBuilderSystem.Contracts;
using ComputerBuilderSystem.SystemComponents;
using ComputerBuilderSystem.SystemTypes;

namespace ComputerBuilderSystem.Manufacturers
{
    public class DellFactory : IManufacturer
    {
        private const int PcAndLaptopCoreNumber = 4;
        private const int ServerCoreNumber = 4;

        private const int PcAndLaptopRamSize = 8;
        private const int ServerRamSize = 64;

        private const int PcAndLaptopDiskSize = 1000;
        private const int ServerDiskSize = 2000;

        public IPcSystem BuildPc()
        {
            IRandomAccessMemmory ram = new RandomAccessMemmory(PcAndLaptopRamSize);
            IVideoCard videoCard = new ColorfulVideoCardDrawingOnConsole();
            IMotherboard motherBoard = new Motherboard(ram, videoCard);
            IDiskDrive hdd = new HardDiskDrive(PcAndLaptopDiskSize);
            ICentralProcessingUnit cpu = new Cpu64Bit(PcAndLaptopCoreNumber);

            IPcSystem resultingSystem = new PersonalComputer(motherBoard, cpu, hdd);

            return resultingSystem;
        }

        public ILaptopSystem BuildLaptop()
        {
            ILaptopBattery battery = new LaptopBattery();
            IRandomAccessMemmory ram = new RandomAccessMemmory(PcAndLaptopRamSize);
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
