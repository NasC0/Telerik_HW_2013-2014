using System;
class Program
{
    static void Main()
    {
        long sum = long.Parse(Console.ReadLine());
        long n = long.Parse(Console.ReadLine());
        long subsetCount = 0;
        long currentSequence = 0;

        for (long i = 0; i < n; i++)
        {
            long currentNumber = long.Parse(Console.ReadLine());
            if (currentNumber == sum)
            {
                subsetCount++;
            }
            else
            {
                currentSequence += currentNumber;

                if (currentSequence == sum)
                {
                    subsetCount++;
                    currentSequence = 0;
                }
                else if (currentSequence > sum)
                {
                    currentSequence = 0;
                }
            }
        }

        Console.WriteLine(subsetCount);
    }
}
