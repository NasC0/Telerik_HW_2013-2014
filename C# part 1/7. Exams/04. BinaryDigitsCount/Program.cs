using System;

class Program
{
    static int LeadingZeroes(long number)
    {
        return (64 - Convert.ToString(number, 2).Length);
    }

    static void Main()
    {
        int bit = int.Parse(Console.ReadLine());
        long numbers = long.Parse(Console.ReadLine());

        for (long i = 0; i < numbers; i++)
        {
            int bitCount = 0;
            long currentNumber = long.Parse(Console.ReadLine());

            int bitLength = 64 - LeadingZeroes(currentNumber);

            for (int j = 0; j < bitLength; j++)
            {
                long result = (currentNumber >> j) & 1;
                if (result == bit)
                {
                    bitCount++;
                }
            }
            Console.WriteLine(bitCount);
        }
    }
}
