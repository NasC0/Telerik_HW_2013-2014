/* 09. * Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float). 
 * Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000. */

using System;

class FloatToBinary
{
    static string FloatingPointToBinary(double number)
    {
        string result = Convert.ToString(BitConverter.DoubleToInt64Bits(number), 2);
        if (result.Length == 64)
        {
            result = result.Remove(0, 1);
        }
        return result;
    }

    static string GetExponent(string binary)
    {
        string exponent = binary[0].ToString();
        exponent += binary.Substring(4, 7);
        return exponent;
    }

    static string GetMantissa(string binary)
    {
        string mantissa = binary.Substring(11);
        return mantissa;
    }

    static void Main()
    {
        Console.WriteLine("Enter the number you want converted");
        double number;
        double.TryParse(Console.ReadLine(), out number);
        string binary = FloatingPointToBinary(number);
        byte sign = 0;
        if (number < 0)
        {
            sign = 1;
        }
        string exponent = GetExponent(binary);
        string mantissa = GetMantissa(binary);
        Console.WriteLine("Sign: {0}", sign);
        Console.WriteLine("Exponent: {0}", exponent);
        Console.WriteLine("Mantissa: {0}", mantissa);
    }
}
