/* 03. Write a program that prints to the console which day of the week is today. Use System.DateTime. */

using System;
using System.Globalization;

class DayOfWeek
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        DateTime weekDay = new DateTime();
        weekDay = DateTime.Now;
        Console.WriteLine(weekDay.DayOfWeek);
    }
}
