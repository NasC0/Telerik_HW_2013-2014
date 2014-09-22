/* 17. Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format), 
 * along with the day of week in Bulgarian. */

using System;
using System.Globalization;

class Add6Hours30MinutesToTime
{
    static void Main()
    {
        string dateFormat = "dd.MM.yyyy HH:mm:ss";
        Console.WriteLine("Enter your date and time: ");
        string dateAndTimeString = Console.ReadLine();
        DateTime dateAndTime;
        DateTime.TryParseExact(dateAndTimeString, dateFormat, CultureInfo.GetCultureInfo("bg-BG"), DateTimeStyles.None, out dateAndTime);
        dateAndTime = dateAndTime.AddHours(6.5);
        Console.WriteLine("Date and time is: {0}.", dateAndTime);
        Console.WriteLine("Day of the week is: {0}.", dateAndTime.DayOfWeek);
    }
}
