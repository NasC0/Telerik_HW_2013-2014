using System;
using ComputerBuilderSystem.SystemComponents;

namespace ComputerBuilderSystem
{
    public class CentralProcessingUnit
    {
        public static readonly Random RandomGenerator = new Random();

        private BitType numberOfBits;
        
        private RandomAccessMemmory ram;

        private HardDiskDriveOld videoCard;

        private ColorfulVideoCardDrawingOnConsole vc;

        internal CentralProcessingUnit(byte numberOfCores, BitType bitSize, RandomAccessMemmory ram, HardDiskDriveOld videoCard, ColorfulVideoCardDrawingOnConsole vc)
        {
            this.numberOfBits = bitSize;
            this.ram = ram;
            this.NumberOfCores = numberOfCores;
            this.vc = vc;
        }

        public byte NumberOfCores { get; set; }

        public void SquareNumber()
        {
            var data = this.ram.LoadValue();
            if (data < 0)
            {
                this.vc.Draw("Number too low.");
            }
            else if (data > (int)this.numberOfBits)
            {
                this.vc.Draw("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                this.vc.Draw(string.Format("Square of {0} is {1}.", data, value));
            } 
        }

        //void SquareNumber32()
        //{
        //    var data = this.ram.LoadValue();
        //    if (data < 0)
        //    {
        //        this.videoCard.Draw("Number too low.");
        //    }
        //    else if (data > 500)
        //    {
        //        this.videoCard.Draw("Number too high.");
        //    }
        //    else
        //    {
        //        int value = 0;
        //        for (int i = 0; i < data; i++)
        //        {
        //            value += data;
        //        }

        //        this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
        //    }
        //}

        //void SquareNumber64()
        //{
        //    var data = this.ram.LoadValue();
        //    if (data < 0)
        //    {
        //        this.videoCard.Draw("Number too low.");
        //    }
        //    else if (data > 1000)
        //    {
        //        this.videoCard.Draw("Number too high.");
        //    }
        //    else
        //    {
        //        int value = 0;
        //        for (int i = 0; i < data; i++)
        //        {
        //            value += data;
        //        }

        //        this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
        //    }
        //}

        internal void Rand(int a, int b)
        {
            int randomNumber;
            do
            {
                randomNumber = RandomGenerator.Next(0, 1000);
            }
            while (!(randomNumber >= a && randomNumber <= b));
            this.ram.SaveValue(randomNumber);
        }
    }
}