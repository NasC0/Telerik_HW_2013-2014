/* 7. Write a program that finds the greatest of given 5 variables. */

using System;

class GreaterOfFive
{
    static void Main()
    {
        // Initialise array that holds the variables
        double[] numbers = new double[5];
        
        // Declare @biggest which holds the current biggest number (set to 0 because of compile-time "undeclared variable" error)
        double biggest = 0;

        // Iterate over the array to fill it and check for the biggest number
        for (int i = 0; i < 5; i++)
        {
            double.TryParse(Console.ReadLine(), out numbers[i]);
            // set @biggest to first array member in case of all negative numbers (i. e. {-2, -3, -4, -5, -6} which will return @biggest = 0 if not set)
            if (i == 0)
            {
                biggest = numbers[i];
            }

            // Check for the biggest variable
            if (numbers[i] > biggest)
            {
                biggest = numbers[i];
            }
        }
        Console.WriteLine("The biggest number is {0}", biggest);
    }
}

