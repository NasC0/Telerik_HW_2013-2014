using System;
using ComputerBuilderClasses.Contracts;

namespace ComputerBuilderClasses.SystemComponents
{
    public abstract class BaseCpu : ICentralProcessingUnit
    {
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
            if (data < 0)
            {
                throw new ArgumentException("Passed data must be positive.");
            }

            if (data > this.BitSize)
            {
                throw new ArgumentException("Passed data must be in the range of the bitsize");
            }

            int value = 0;
            for (int i = 0; i < data; i++)
            {
                value += data;
            }

            return value;
        }

        public int Rand(Random randomGenerator, int minValue, int maxValue)
        {
            int randomNumber = randomGenerator.Next(minValue, maxValue);
            return randomNumber;
        }
    }
}