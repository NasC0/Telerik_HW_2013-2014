/* 01. Write a program that reads an integer number and calculates and prints its square root. 
 * If the number is invalid or negative, print "Invalid number". 
 * In all cases finally print "Good bye". Use try-catch-finally. */

using System;

class CalcSquareRoot
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter your number: ");
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentException("Number must not be negative!");
            }
            double numberSquared = Math.Sqrt(number);
            Console.WriteLine("Square root of {0}: {1}", number, numberSquared);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Good-bye");
        }
    }
}
