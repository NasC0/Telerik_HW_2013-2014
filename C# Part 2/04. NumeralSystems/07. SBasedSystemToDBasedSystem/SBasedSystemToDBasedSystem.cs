/* 07. Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16). */

using System;
using System.Text;

class SBasedSystemToDBasedSystem
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

    static int SBasedNumber(string number, int baseSystem)
    {
        number = ReverseString(number);
        int result = 0;

        // Position 0
        result += hex.IndexOf(number[0]);

        // position 1
        if (number.Length >= 2)
        {
            result += hex.IndexOf(number[1]) * baseSystem;
        }

        for (int i = 2; i < number.Length; i++)
        {
            result += (hex.IndexOf(number[i]) * (int)Math.Pow(baseSystem, i));
        }

        return result;
    }

    static string DBasedNumber(int number, int baseSystem)
    {
        StringBuilder sb = new StringBuilder();
        while (number > 0)
        {
            int remainder = number % baseSystem;
            number /= baseSystem;
            sb.Append(hex[remainder]);
        }

        string result = ReverseString(sb.ToString());
        return result;
    }

    static void Main()
    {
        Console.WriteLine("Enter the first number, it's base system, and the base of the system you want it converted to:  ");
        Console.Write("Number: ");
        string number = Console.ReadLine();
        int firstBaseSystem, secondBaseSystem;
        Console.Write("First base: ");
        int.TryParse(Console.ReadLine(), out firstBaseSystem);
        Console.Write("Second base: ");
        int.TryParse(Console.ReadLine(), out secondBaseSystem);
        int result = SBasedNumber(number, firstBaseSystem);
        string resultString = DBasedNumber(result, secondBaseSystem);
        Console.WriteLine("The number {0} in {1} base system converted to {2} base system is: {3}", number, firstBaseSystem, secondBaseSystem, resultString);
    }
}
