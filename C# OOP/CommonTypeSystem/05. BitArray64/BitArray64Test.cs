using System;
namespace _05.BitArray64
{
    class BitArray64Test
    {
        static Random randomGen = new Random();

        static void Main()
        {
            BitArray64 bitArray = new BitArray64(3216549);

            Console.WriteLine(bitArray.Value);

            Console.WriteLine(bitArray.GetHashCode());

            BitArray64 secondBitArray = new BitArray64();

            if (bitArray == secondBitArray)
            {
                Console.WriteLine("The two are equal.");
            }
            else
            {
                Console.WriteLine("The two are not equal.");
            }

            for (int i = 0; i < 64; i++)
            {
                secondBitArray[i] = (byte)randomGen.Next(0, 2);
            }

            Console.WriteLine(secondBitArray);

            Console.WriteLine(secondBitArray.Value);

            Console.WriteLine(secondBitArray.GetHashCode());

            foreach (int bit in secondBitArray)
            {
                Console.WriteLine(bit);
            }
        }
    }
}
