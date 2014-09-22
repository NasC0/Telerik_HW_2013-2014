using System;
using System.Numerics;

class QuadronacciRectangle
{
    static void Main()
    {
        checked
        {
            BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
            BigInteger secondNum = BigInteger.Parse(Console.ReadLine());
            BigInteger thirdNum = BigInteger.Parse(Console.ReadLine());
            BigInteger fourthNum = BigInteger.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            BigInteger currentNumber = 0;
            bool passedFirst = false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (passedFirst)
                    {
                        currentNumber = firstNum + secondNum + thirdNum + fourthNum;
                        Console.Write("{0} ", currentNumber);
                        firstNum = secondNum;
                        secondNum = thirdNum;
                        thirdNum = fourthNum;
                        fourthNum = currentNumber;
                    }
                    else
                    {
                        Console.Write("{0} {1} {2} {3} ", firstNum, secondNum, thirdNum, fourthNum);
                        j = 3;
                        passedFirst = true;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
