/* 4. Sort 3 real values in descending order using nested if statements. */

using System;

class SortThreeValues
{
    static void Main()
    {
        double firstNum, secondNum, thirdNum;
        double.TryParse(Console.ReadLine(), out firstNum);
        double.TryParse(Console.ReadLine(), out secondNum);
        double.TryParse(Console.ReadLine(), out thirdNum);

        if (firstNum > secondNum)
        {
            if (firstNum > thirdNum)
            {
                double temp = 0;
                if (thirdNum > secondNum)
                {
                    temp = secondNum;
                    secondNum = thirdNum;
                    thirdNum = temp;
                }
                Console.WriteLine("{0} {1} {2}", firstNum, secondNum, thirdNum);
            }
            else
            {
                double temp = firstNum;
                firstNum = thirdNum;
                thirdNum = secondNum;
                secondNum = temp;
                Console.WriteLine("{0} {1} {2}", firstNum, secondNum, thirdNum);
            }
        }
        else if (secondNum > firstNum)
        {
            if (secondNum > thirdNum)
            {
                double temp = 0;
                if (thirdNum > firstNum)
                {
                    temp = firstNum;
                    firstNum = thirdNum;
                    thirdNum = temp;
                }
                temp = secondNum;
                secondNum = firstNum;
                firstNum = temp;
                Console.WriteLine("{0} {1} {2}", firstNum, secondNum, thirdNum);
            }
            else
            {
                double temp = firstNum;
                firstNum = thirdNum;
                thirdNum = temp;

                Console.WriteLine("{0} {1} {2}", firstNum, secondNum, thirdNum);
            }
        }
    }
}

