using System;
using System.Numerics;

class TribonacciSequence
{
    static void Main()
    {
        checked
        {
            BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
            BigInteger secondNum = BigInteger.Parse(Console.ReadLine());
            BigInteger thirdNum = BigInteger.Parse(Console.ReadLine());
            int sequenceLength = int.Parse(Console.ReadLine());
            BigInteger currentNum = 0;

            if (sequenceLength == 1)
            {
                Console.WriteLine(firstNum);
            }
            else if (sequenceLength == 2)
            {
                Console.WriteLine(secondNum);
            }
            else if (sequenceLength == 3)
            {
                Console.WriteLine(thirdNum);
            }
            else
            {
                for (int i = 3; i < sequenceLength; i++)
                {
                    currentNum = firstNum + secondNum + thirdNum;
                    firstNum = secondNum;
                    secondNum = thirdNum;
                    thirdNum = currentNum;
                }

                Console.WriteLine(currentNum);
            }
        }
    }
}
