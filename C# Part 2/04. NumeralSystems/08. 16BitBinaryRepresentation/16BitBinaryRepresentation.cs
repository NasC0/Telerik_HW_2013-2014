/* 08. Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short). */

using System;
using System.Text;

class _16BitBinaryRepresentation
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

    static string BinaryRepresentation(int number)
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;
        for (int i = 1; i <= 16; i++)
        {
            sb.Append((number >> count) & 1);
            if (i % 4 == 0)
            {
                sb.Append(' ');
            }
            count++;
        }
        if (number > 0)
        {
            sb.Append("0");
        }
        else
        {
            sb.Append("1");
        }
        string result = ReverseString(sb.ToString());
        return result;
    }
    static void Main()
    {
        Console.WriteLine("Enter the number you want converted to binary: ");
        int number;
        int.TryParse(Console.ReadLine(), out number);
        string binaryNumber = BinaryRepresentation(number);
        Console.WriteLine(binaryNumber);
    }
}
