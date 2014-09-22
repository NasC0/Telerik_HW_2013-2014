/* 02. Write a program to convert binary numbers to their decimal representation. */

using System;
using System.Text;

class BinaryToDecimal
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
    static int ConvertBinaryToDecimal(string number)
    {
        int result = 0;

        number = ReverseString(number);

        // For the 0 bit position
        result += (int)Char.GetNumericValue(number[0]);

        // For the 1 bit position
        if (number[1] != '0' && number.Length >= 2)
        {
            result += 2;
        }

        for (int i = 2; i < number.Length; i++)
        {
            if (number[i] == '0')
            {
                continue;
            }

            result += (int)Char.GetNumericValue(number[i]) << i;
        }

        return result;
    }
    static void Main()
    {
        Console.WriteLine("Enter the binary number you want converted");
        Console.WriteLine("Example: 100 = 1100100: ");
        string number = Console.ReadLine();
        int result = ConvertBinaryToDecimal(number);
        Console.WriteLine(result);
    }
}