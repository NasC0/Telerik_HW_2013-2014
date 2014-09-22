/* 11. * Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
	0 -> "Zero"
	273 -> "Two hundred seventy three"
	400 -> "Four hundred"
	501 -> "Five hundred and one"
	711 -> "Seven hundred and eleven" */

using System;

class ConverNumberToText
{
    public static string PrintOnes(int number)
    {
        switch (number)
        {
            case 1:
                return "One";
                break;
            case 2:
                return "Two";
                break;
            case 3:
                return "Three";
                break;
            case 4:
                return "Four";
                break;
            case 5:
                return "Five";
                break;
            case 6:
                return "Six";
                break;
            case 7:
                return "Seven";
                break;
            case 8:
                return "Eight";
                break;
            case 9:
                return "Nine";
                break;
            default:
                return "Zero";
                break;
        }
    }

    public static string PintSpecials(int number)
    {
        switch (number)
        {
            case 11:
                return "Eleven";
                break;
            case 12:
                return "Twelve";
                break;
            case 13:
                return "Thirteen";
                break;
            case 14:
                return "Fourteen";
                break;
            case 15:
                return "Fifteen";
                break;
            case 16:
                return "Sixteen";
                break;
            case 17:
                return "Seventeen";
                break;
            case 18:
                return "Eighteen";
                break;
            case 19:
                return "Nineteen";
                break;
            default:
                return "Ten";
                break;
        }
    }

    public static string PrintTens(int number)
    {
        switch (number)
        {
            case 2:
                return "Twenty";
                break;
            case 3:
                return "Thirty";
                break;
            case 4:
                return "Forty";
                break;
            case 5:
                return "Fifty";
                break;
            case 6:
                return "Sixty";
                break;
            case 7:
                return "Seventy";
                break;
            case 8:
                return "Eighty";
                break;
            case 9:
                return "Ninety";
                break;
            default:
                return "";
                break;
        }
    }

    public static string PrintHundreds(int number)
    {
        switch (number)
        {
            case 1:
                return "One hundred";
                break;
            case 2:
                return "Two hundred";
                break;
            case 3:
                return "Three hundred";
                break;
            case 4:
                return "Four hundred";
                break;
            case 5:
                return "Five hundred";
                break;
            case 6:
                return "Six hundred";
                break;
            case 7:
                return "Seven hundred";
                break;
            case 8:
                return "Eight hundred";
                break;
            case 9:
                return "Nine hundred";
                break;
            default:
                return "";
                break;
        }
    }
    static void Main()
    {
        Console.Write("Please enter your number: ");
        int number;
        int.TryParse(Console.ReadLine(), out number);
        if (number < 10 && number >= 0)
        {
            Console.WriteLine(PrintOnes(number));
        }
        else if (number >= 10 && number < 20)
        {
            Console.WriteLine(PintSpecials(number));
        }
        else if (number >= 20 && number < 100)
        {
            int tens = number / 10;
            int digits = number % 10;
            string output = PrintTens(tens);

            if (digits != 0)
            {
                output += String.Format(" {0}", PrintOnes(digits));
            }

            Console.WriteLine(output);
        }
        else if (number >= 100 && number < 1000)
        {
            int hundreds = number / 100;
            string output = PrintHundreds(hundreds);
            int remainder = number % 100;
            if (remainder >= 10 && remainder < 20)
            {
                output += String.Format(" and {0}", PintSpecials(remainder));
                Console.WriteLine(output);
            }
            else
            {
                int tens = remainder / 10;
                int ones = remainder % 10;
                if (tens == 0 && ones == 0)
                {
                    Console.WriteLine(output);
                }
                else if (tens == 0 && ones > 0)
                {
                    output += String.Format(" and {0}", PrintOnes(ones));
                    Console.WriteLine(output);
                }
                else if (tens > 0 && ones == 0)
                {
                    output += String.Format(" and {0}", PrintTens(tens));
                    Console.WriteLine(output);
                }
                else
                {
                    output += String.Format(" {0} {1}", PrintTens(tens), PrintOnes(ones));
                    Console.WriteLine(output);
                }
            }
        }
    }
}
