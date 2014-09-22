/* 02. Write a program that reads a string, reverses it and prints the result at the console.
 * Example: "sample"  "elpmas". */

using System;
using System.Text;

class ReverseString
{
    static string ReverseGivenString(string input)
    {
        StringBuilder reversedString = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversedString.Append(input[i]);
        }

        return reversedString.ToString();
    }

    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Console.WriteLine(ReverseGivenString(input));
    }
}