/* 01. Write a program that reads a year from the console and checks whether it is a leap. Use DateTime. */

using System;

class IsYearLeap
{
    static void Main()
    {
        Console.WriteLine("Enter the year you want checked: ");
        int year;
        int.TryParse(Console.ReadLine(), out year);
        Console.WriteLine("{0} is leap year: {1}", year, DateTime.IsLeapYear(year));
    }
}
