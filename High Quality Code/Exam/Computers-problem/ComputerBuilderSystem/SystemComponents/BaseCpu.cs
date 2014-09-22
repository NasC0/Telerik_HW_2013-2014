using System;
using ComputerBuilderSystem.Contracts;

namespace ComputerBuilderSystem.SystemComponents
{
    public abstract class BaseCpu : ICentralProcessingUnit
    {
        public static readonly Random RandomGenerator = new Random();

        private byte numberOfCores;

        private int bitSize;

        public BaseCpu(byte numberOfCores, int bitSize)
        {
            this.NumberOfCores = numberOfCores;
            this.BitSize = bitSize;
        }

        public byte NumberOfCores
        {
            get
            {
                return this.numberOfCores;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("CPU Core number must be positive.");
                }

                this.numberOfCores = value;
            }
        }

        public int BitSize
        {
            get
            {
                return this.bitSize;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("CPU bit size must be positive.");
                }

                this.bitSize = value;
            }
        }

        public int SquareNumber(int data)
        {
            int value = 0;
            for (int i = 0; i < data; i++)
            {
                value += data;
            }

            return value;
        }

        public int Rand(int minValue, int maxValue)
        {
            int randomNumber = RandomGenerator.Next(minValue, maxValue);
            return randomNumber;
        }
    }
}