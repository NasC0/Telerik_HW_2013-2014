using System;
using System.Collections.Generic;
using ComputerBuilderClasses.Contracts;

namespace ComputerBuilderClasses.SystemComponents
{
    public class HardDiskDrive : IDiskDrive
    {
        private int capacity;

        private Dictionary<int, string> data;

        public HardDiskDrive(int capacity)
        {
            this.Capacity = capacity;
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
                    throw new ArgumentException("Hard drive capacity must be a positive number.");
                }

                this.capacity = value;
            }
        }

        public void SaveData(int memmoryAddress, string textData)
        {
            this.data.Add(memmoryAddress, textData);
        }

        public string LoadData(int memmoryAddress)
        {
            return this.data[memmoryAddress];
        }
    }
}
