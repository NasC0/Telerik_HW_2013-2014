/* 04. Write a program to convert hexadecimal numbers to their decimal representation. */

using System;
using System.Text;

class HexadecimalToDecimal
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

    static long HexToDecimal(string number)
    {
        long result = 0;
        number = ReverseString(number);

        // Case position 0
        result += hex.IndexOf(number[0]);

        // Case position 1
        if (number.Length >= 2)
        {
            result += hex.IndexOf(number[1]) * 16;
        }

        for (int i = 2; i < number.Length; i++)
        {
            // The formula (i - 1) * 4 is derived from the need to use the power of 16.
            // In the case of i = 2, it translates to 16 ^ 2 (16 << 4)
            // i = 3: 16 ^ 3 16 << 8 and so forth
            int currentSum = hex.IndexOf(number[i]) * 16 << ((i - 1) * 4);
            result += currentSum;
        }

        return result;
    }

    static void Main()
    {
        Console.Write("Enter the hex number you want converted: ");
        string hexNum = Console.ReadLine();
        long result = HexToDecimal("FFFFFFF");
        Console.WriteLine(result);
    }
}
