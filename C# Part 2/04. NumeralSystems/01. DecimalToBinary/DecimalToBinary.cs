/* 01. Write a program to convert decimal numbers to their binary representation. */

using System;
using System.Text;
using System.Linq;

class DecimalToBinary
{

    static string ReverseString(string input)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            sb.Append(input[i]);
        }

        return sb.ToString();
    }

    static string ConvertDecimalToBinary(int number)
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;
        for (int i = 1; i <= 32; i++)
        {
            int insert = (number >> count) & 1;
            count++;
            sb.Append(insert);
            if (i % 4 == 0)
            {
                sb.Append(' ');
            }
        }
        sb.Remove(sb.Length - 1, 1);
        string result = ReverseString(sb.ToString());
        return result;
    }

    static void Main()
    {
        int number;
        Console.WriteLine("Enter the number you want converted to binary: ");
        int.TryParse(Console.ReadLine(), out number);
        string convert = ConvertDecimalToBinary(number);
        Console.WriteLine(convert);
    }
}