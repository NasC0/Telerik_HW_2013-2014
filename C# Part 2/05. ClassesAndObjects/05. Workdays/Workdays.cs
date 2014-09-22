/* 05. Write a method that calculates the number of workdays between today and given date, passed as parameter. 
 * Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
 * Bear in mind the program does not consider floating off days, like the additional offdays around Easter, March 3rd, May 24th, etc */

using System;
using System.Collections.Generic;

class Workdays
{

    // List of strings to allow easy parsing in the CheckOffDay method
    static List<string> holidays = new List<string>()
    {
        "1,1", // New years day
        "3,3", // Salvation day
        "5,1", // Labor Day
        "5,6", // Georgi Namesday
        "5,24", // Bulgarian Culture day
        "9,6", // Union day
        "9,22", // Independence day
        "11,1", // Apostole Day
        "12,24", // Christmas
        "12,25",
        "12,26"
    };


    static List<DateTime> easterDays = new List<DateTime>();

    // Calculating easter day as per http://aa.usno.navy.mil/faq/docs/easter.php
    static DateTime CalculateEasterDay(int year)
    {
        int a, b, c, d, e, f, g, h, i, k, l, m, easterMonth, easterDay;
        a = year % 19;
        b = year / 100;
        c = year % 100;
        d = b / 4;
        e = b % 4;
        f = (b + 8) / 25;
        g = (b - f + 1) / 3;
        h = (19 * a + b - d - g + 15) % 30;
        i = c / 4;
        k = c % 4;
        l = (32 + 2 * e + 2 * i - h - k) % 7;
        m = (a + 11 * h + 22 * l) / 451;
        easterMonth = (h + l - 7 * m + 114) / 31;
        easterDay = (h + l - 7 * m + 114) % 31;
        easterDay++;
        DateTime result = new DateTime(year, easterMonth, easterDay);
        return result;
    }

    static bool CheckOffDay(DateTime date)
    {
        string toCompare = String.Format("{0},{1}", date.Day, date.Month);
        if (holidays.Contains(toCompare) || easterDays.Contains(date) || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        DateTime start = DateTime.Today;
        DateTime end = new DateTime();
        Console.WriteLine("Please enter the end date in the format yyyy-mm-dd ");
        Console.WriteLine("E.G. 2014-1-9 (January 1st)");
        DateTime.TryParse(Console.ReadLine(), out end);
        if (start > end)
        {
            Console.WriteLine("Please enter a valid date!");
            return;
        }
        if (start.Year != end.Year)
        {
            DateTime startEaster = CalculateEasterDay(start.Year);
            DateTime endEaster = CalculateEasterDay(end.Year);

            if (start < startEaster)
            {
                easterDays.Add(startEaster);
            }

            int calculateYear = start.Year + 1;
            while (calculateYear < end.Year)
            {
                easterDays.Add(CalculateEasterDay(calculateYear));
                calculateYear++;
            }

            if (end > endEaster)
            {
                easterDays.Add(endEaster);
            }

        }

        int workDays = 0;
        DateTime startTemp = start;
        while (startTemp <= end)
        {
            if (!CheckOffDay(startTemp))
            {
                workDays++;
            }
            startTemp = startTemp.AddDays(1);
        }

        Console.WriteLine(workDays);
    }
}
