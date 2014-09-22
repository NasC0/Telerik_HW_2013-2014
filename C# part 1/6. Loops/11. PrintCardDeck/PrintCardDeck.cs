/* 11. Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). 
 * The cards should be printed with their English names. Use nested for loops and switch-case. */
using System;

class PrintCardDeck
{

    // Declare functions that return the paint and power of each card
    public static string PrintPaint(int number)
    {
        switch (number)
        {
            case 1:
                return "Clubs";
                break;
            case 2:
                return "Diamonds";
                break;
            case 3:
                return "Hears";
                break;
            case 4:
                return "Spades";
                break;
            default:
                return "Invalid";
                break;
        }
    }

    public static string PrintPower(int number)
    {
        switch (number)
        {
            case 1:
                return "Ace";
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
            case 10:
                return "Ten";
                break;
            case 11:
                return "Jack";
                break;
            case 12:
                return "Queen";
                break;
            case 13:
                return "King";
                break;
            default:
                return "Invalid";
                break;
        }
    }
    static void Main()
    {
        for (int i = 1; i < 5; i++)
        {
            string paint = PrintPaint(i);
            Console.WriteLine(paint);
            for (int j = 1; j < 14; j++)
            {
                string print = String.Format("{1} of {0}", paint, PrintPower(j));
                Console.WriteLine(print);
            }
            Console.WriteLine();
        }
    }
}