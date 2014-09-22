/* 12. Write a program to read your age from the console and print how old you will be after 10 years. */

using System;

class CalculateAge
{
    static void Main()
    {
        int age = 0;
        Console.Write("Enter your age please: ");
        int.TryParse(Console.ReadLine(), out age);
        age += 10;
        Console.WriteLine("In 10 years you will be {0} years old", age);
    }
}