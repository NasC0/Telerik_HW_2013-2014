/* Write a program to convert hexadecimal numbers to binary numbers (directly). */

using System;
using System.Text;

class HexadecimalToBinary
{
    static string hex = "0123456789ABCDEF";

    static string HexToBinary(string hexNumber)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hexNumber.Length; i++)
        {
            int currentNumber = hex.IndexOf(hexNumber[i]);

            for (int j = 3; j >= 0; j--)
            {
                int bit = (currentNumber >> j) & 1;
                sb.Append(bit);
            }
            sb.Append(' ');
        }
        sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Enter the hex number you want converted to binary: ");
        string hexNumber = Console.ReadLine();
        string binary = HexToBinary(hexNumber);
        Console.WriteLine(binary);
    }
}
