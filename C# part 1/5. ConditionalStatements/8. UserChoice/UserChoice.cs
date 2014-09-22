/* 8. Write a program that, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. 
 * If the variable is string, appends "*" at its end. The program must show the value of that variable as a console output. Use switch statement. */

using System;

class UserChoice
{
    static void Main()
    {
        Console.Write("Please enter \"string\", \"double\" or \"int\": ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "string":
                Console.Write("Please enter your string: ");
                string input = Console.ReadLine();
                input += "*";
                Console.WriteLine(input);
                break;
            case "double":
                Console.Write("Please enter your number: ");
                double numberDouble;
                double.TryParse(Console.ReadLine(), out numberDouble);
                numberDouble++;
                Console.WriteLine(numberDouble);
                break;
            case "int":
                Console.Write("Please enter your number: ");
                int numberInt;
                int.TryParse(Console.ReadLine(), out numberInt);
                numberInt++;
                Console.WriteLine(numberInt);
                break;
            default:
                Console.WriteLine("Invalid input!");
                break;
        }
    }
}