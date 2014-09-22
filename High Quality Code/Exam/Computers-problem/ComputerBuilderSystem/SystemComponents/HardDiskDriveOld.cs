using System;
using System.Collections.Generic;
using System.Linq;
using ComputerBuilderSystem.Contracts;

namespace ComputerBuilderSystem
{
    class HardDiskDriveOld : IDiskDrive
    {
        bool isInRaid;

        int hardDrivesInRaid;

        List<HardDiskDriveOld> hds;

        int capacity;

        Dictionary<int, string> data;

        internal HardDiskDriveOld()
        {
        }
        
        internal HardDiskDriveOld(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;

            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);

            this.hds = new List<HardDiskDriveOld>();
        }

        internal HardDiskDriveOld(int capacity, bool isInRaid, int hardDrivesInRaid, List<HardDiskDriveOld> hardDrives)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;

            this.data = new Dictionary<int, string>(capacity);
            this.hds = new List<HardDiskDriveOld>();
            this.hds = hardDrives;
        }

        public bool IsMonochrome { get; set; }

        int Capacity
        {
            get
            {
                if (isInRaid)
                {
                    if (!this.hds.Any())
                    {
                        return 0;
                    }

                    return this.hds.First().Capacity;
                }
                else
                {
                    return capacity;
                }
            }
        }

        void SaveData(int addr, string newData)
        {
            if (isInRaid)
            {
                foreach (var hardDrive in this.hds)
                {
                    hardDrive.SaveData(addr, newData);
                }
            }
            else
            {
                this.data[addr] = newData;
            }
        }

        string LoadData(int address)
        {
            if (isInRaid)
            {
                if (!this.hds.Any())
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }

                return this.hds.First().LoadData(address);
            }
            else if (true)
            {
                return this.data[address];
            }
        }

        public void Draw(string a)
        {
            if (this.IsMonochrome)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(a);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(a);
                Console.ResetColor();
            }
        }

        int IDiskDrive.Capacity
        {
            get { throw new NotImplementedException(); }
        }

        void IDiskDrive.SaveData(int memmoryAddress, string textData)
        {
            throw new NotImplementedException();
        }

        string IDiskDrive.LoadData(int memmoryAddress)
        {
            throw new NotImplementedException();
        }
    }
}