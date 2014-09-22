/* 12. Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix */

using System;

class PrintMatrix
{
    static void Main()
    {
        Console.WriteLine("Input N: ");
        int rows;
        int.TryParse(Console.ReadLine(), out rows);
        if (rows > 19 && rows < 1)
        {
            Console.WriteLine("Invalid input!");
        }
        else
        {
            for (int i = 0; i < rows; i++)
            {
                int counter = i + 1;
                for (int j = 0; j < rows; j++)
                {
                    Console.Write("{0} ", counter);
                    counter++;
                }
                Console.WriteLine();
            }
        }
    }
}
