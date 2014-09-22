/* 03. Write a program to convert decimal numbers to their hexadecimal representation. */

using System;
using System.Text;

class DecimalToHexadecimal
{
    static string hex = "0123456789ABCDEF";

    static string ReverseString(string input)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            sb.Append(input[i]);
        }

        return sb.ToString();
    }

    static string DecimalToHex(int number)
    {
        StringBuilder sb = new StringBuilder();
        while (number > 0)
        {
            int remainder = number % 16;
            number /= 16;
            sb.Append(hex[remainder]);
        }
        string result = ReverseString(sb.ToString());
        return result;
    }
    static void Main()
    {
        Console.Write("Enter the number you want converted to hex: ");
        int number;
        int.TryParse(Console.ReadLine(), out number);
        string numberHex = DecimalToHex(number);
        Console.WriteLine(numberHex);
    }
}
