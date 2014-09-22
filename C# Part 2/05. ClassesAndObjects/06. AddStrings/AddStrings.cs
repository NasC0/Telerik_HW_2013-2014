/* 06. You are given a sequence of positive integer values written into a string, separated by spaces.
 * Write a function that reads these values from given string and calculates their sum. 
 * Example: string = "43 68 9 23 318"  result = 461 */

using System;

class AddStrings
{
    static int AddString(string numbers)
    {
        string[] split = numbers.Split(' ');
        int result = 0;
        for (int i = 0; i < split.Length; i++)
        {
            int currentNumber;
            int.TryParse(split[i], out currentNumber);
            result += currentNumber;
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("Enter the string: ");
        string numbers = Console.ReadLine();

        int result = AddString(numbers);
        Console.WriteLine(result);
    }
}
