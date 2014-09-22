using System;
using TestDayOfWeek.DayOfWeekService;

namespace TestDayOfWeek
{
    public class TestDayOfWeek
    {
        public static void Main()
        {
            var serviceClient = new DayOfWeekClient();
            var yesterday = DateTime.Now.AddDays(-1);
            string dayOfWeekFromYesterday = serviceClient.GetDayOfWeek(yesterday);
            Console.WriteLine(dayOfWeekFromYesterday);
        }
    }
}
