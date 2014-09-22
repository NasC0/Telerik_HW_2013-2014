/* 3. Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them. */

using System;

class MinimalAndMaximal
{
    static void Main()
    {
        Console.Write("Please input how many integers you want to enter: ");
        int numbers;
        int.TryParse(Console.ReadLine(), out numbers);
        int minimal = 0, maximal = 0;

        for (int i = 0; i < numbers; i++)
        {
            int currentNumber;
            int.TryParse(Console.ReadLine(), out currentNumber);
            if (i == 0)
            {
                minimal = currentNumber;
                maximal = currentNumber;
            }
            else
            {
                if (currentNumber > maximal)
                {
                    maximal = currentNumber;
                }
                else if (minimal > currentNumber)
                {
                    minimal = currentNumber;
                }
            }
        }

        Console.WriteLine("The minimal number is: {0}", minimal);
        Console.WriteLine("The maximal number is: {0}", maximal);
    }
}
