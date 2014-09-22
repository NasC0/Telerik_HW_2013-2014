/* Write a program that reads from the console a string of maximum 20 characters. 
 * If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
 * Print the result string into the console. */

using System;
using System.Text;

class FillStringClass
{
    static string FillString(string input)
    {
        if (input.Length > 20)
        {
            throw new ArgumentOutOfRangeException();
        }
        else if (input.Length == 20)
        {
            return input;
        }
        else
        {
            StringBuilder sb = new StringBuilder(20);
            for (int i = 0; i < 20; i++)
            {
                if (i < input.Length)
                {
                    sb.Append(input[i]);
                }
                else if (i >= input.Length)
                {
                    sb.Append('*');
                }
            }
            return sb.ToString();
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter your string (must not contain more than 20 characters: ");
        string str = Console.ReadLine();
        try
        {
            str = FillString(str);
            Console.WriteLine(str);
        }
        catch
        {
            Console.WriteLine("Your string must not contain more than 20 characters!");
        }
    }
}
