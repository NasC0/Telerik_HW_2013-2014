/* 06. Write a program to convert binary numbers to hexadecimal numbers (directly). */

using System;
using System.Text;

class BinaryToHexadecimal
{
    static string BinaryToHex(string binary)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder binaryByte = new StringBuilder();
        int loopCount = binary.Length / 4;
        int start = 0;
        for (int i = 0; i < loopCount; i++)
        {
            binaryByte.Clear();
            binaryByte.Append(binary.Substring(start, 4));
            start += 4;
            switch (binaryByte.ToString())
            {
                case "0000":
                    sb.Append('0');
                    break;
                case "0001":
                    sb.Append('1');
                    break;
                case "0010":
                    sb.Append('2');
                    break;
                case "0011":
                    sb.Append('3');
                    break;
                case "0100":
                    sb.Append('4');
                    break;
                case "0101":
                    sb.Append('5');
                    break;
                case "0110":
                    sb.Append('6');
                    break;
                case "0111":
                    sb.Append('7');
                    break;
                case "1000":
                    sb.Append('8');
                    break;
                case "1001":
                    sb.Append('9');
                    break;
                case "1010":
                    sb.Append('A');
                    break;
                case "1011":
                    sb.Append('B');
                    break;
                case "1100":
                    sb.Append('C');
                    break;
                case "1101":
                    sb.Append('D');
                    break;
                case "1110":
                    sb.Append('E');
                    break;
                case "1111":
                    sb.Append('F');
                    break;
                default:
                    sb.Append("");
                    break;
            }
        }

        return sb.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Enter the binary number you want converted");
        Console.WriteLine("Example: 00110100 = 34");
        string binary = Console.ReadLine();
        string hex = BinaryToHex(binary);
        Console.WriteLine(hex);
    }
}
