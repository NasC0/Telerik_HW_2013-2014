/* 7. Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. */

using System;

class PritNNumberSum
{
    static void Main()
    {
        Console.Write("Please enter the number of numbers you want: ");
        int numbers;
        int.TryParse(Console.ReadLine(), out numbers);
        double sum = 0;

        for (int i = 0; i < numbers; i++)
        {
            double currentNumber;
            double.TryParse(Console.ReadLine(), out currentNumber);

            sum += currentNumber;
        }

        Console.WriteLine("The sum of the numbers is: {0}", sum);
    }
}
