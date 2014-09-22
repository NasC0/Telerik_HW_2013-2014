/* 2. Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements. */

using System;

class PrintProductSign
{
    static void Main()
    {
        double firstNum, secondNum, thirdNum;
        double.TryParse(Console.ReadLine(), out firstNum);
        double.TryParse(Console.ReadLine(), out secondNum);
        double.TryParse(Console.ReadLine(), out thirdNum);

        if (firstNum < 0 && secondNum < 0 && thirdNum < 0)
        {
            Console.WriteLine("The product of these numbers will be negative");
        }
        else if (firstNum > 0 && secondNum > 0 && thirdNum > 0)
        {
            Console.WriteLine("The product of these numbers will be positive");
        }
        else if ((firstNum < 0 && secondNum < 0 && thirdNum > 0)
            || (firstNum < 0 && secondNum > 0 && thirdNum < 0)
            || (firstNum > 0 && secondNum < 0 && thirdNum < 0))
        {
            Console.WriteLine("The product of these numbers will be positive");
        }
        else if ((firstNum < 0 && secondNum > 0 && thirdNum > 0)
            || (firstNum > 0 && secondNum > 0 && thirdNum < 0)
            || (firstNum > 0 && secondNum < 0 && thirdNum > 0))
        {
            Console.WriteLine("The product of these numbers will be negative");
        }
    }
}
