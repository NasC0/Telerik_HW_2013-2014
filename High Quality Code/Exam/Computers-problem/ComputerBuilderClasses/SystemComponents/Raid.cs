using System;
using System.Collections.Generic;
using System.Linq;
using ComputerBuilderClasses.Contracts;

namespace ComputerBuilderClasses.SystemComponents
{
    public class Raid : IRaid, IDiskDrive
    {
        private IEnumerable<IDiskDrive> hdds;

        private int capacity;

        public Raid(IEnumerable<IDiskDrive> diskDrives, int capacity)
        {
            this.Hdds = diskDrives;
            this.Capacity = capacity;
        }

        public IEnumerable<IDiskDrive> Hdds
        {
            get
            {
                return this.hdds;
            }

            private set
            {
                if (value == null) 
                {
                    throw new ArgumentNullException("Disk drive collection must be initialized.");
                }

                if (value.Count() < 1)
                {
                    throw new ArgumentException("Disk drive collection must have at least 1 element.");
                }

                this.hdds = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Disk drive capacity must be a positive number.");
                }

                this.capacity = value;
            }
        }

        public void SaveData(int memmoryAddress, string textData)
        {
            foreach (var hdd in this.Hdds)
            {
                hdd.SaveData(memmoryAddress, textData);
            }
        }

        public string LoadData(int memmoryAddress)
        {
            if (this.Hdds.Count() <= 0)
            {
                throw new ArgumentException("No hard drive in the RAID array!");
            }

            return this.Hdds.First().LoadData(memmoryAddress);
        }
    }
}