/* 02. Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
 * If an invalid number or non-number text is entered, the method should throw an exception. 
 * Using this method write a program that enters 10 numbers:
 * a1, a2, … a10, such that 1 < a1 < … < a10 < 100 */

using System;

class ReadNumbers
{
    static int ReadNumber(int start, int end)
    {
        int number;
        if (int.TryParse(Console.ReadLine(), out number))
        {
            if (number <= start || number >= end)
            {
                throw new ArgumentOutOfRangeException(String.Format("Number was not in range [{0} ... {1}] exclusive", start, end));
            }
            else
            {
                return number;
            }
        }
        else
        {
            throw new ArgumentException("Non-number or invalid number text entered.");
        }
    }
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter your numbers in ascending order in the range [1 ... 100] exclusive: ");
            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    numbers[i] = ReadNumber(1, 100);
                }
                else
                {
                    numbers[i] = ReadNumber(numbers[i - 1], 100);
                }
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
