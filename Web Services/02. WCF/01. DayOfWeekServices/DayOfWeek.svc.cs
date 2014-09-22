using System;

namespace DayOfWeekServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DayOfWeek" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DayOfWeek.svc or DayOfWeek.svc.cs at the Solution Explorer and start debugging.
    public class DayOfWeek : IDayOfWeek
    {
        public string GetDayOfWeek(DateTime date)
        {
            var dayOfWeek = date.DayOfWeek.ToString();
            return this.TranslateDayOfWeek(dayOfWeek);
        }

        private string TranslateDayOfWeek(string dayOfWeek)
        {
            dayOfWeek = dayOfWeek.ToLower();
            string translatedDayOfWeek = string.Empty;
            switch (dayOfWeek)
            {
                case "monday":
                    translatedDayOfWeek = "Понеделник";
                    break;
                case "tuesday":
                    translatedDayOfWeek = "Вторник";
                    break;
                case "wednesday":
                    translatedDayOfWeek = "Сряда";
                    break;
                case "thursday":
                    translatedDayOfWeek = "Четвъртък";
                    break;
                case "friday":
                    translatedDayOfWeek = "Петък";
                    break;
                case "saturday":
                    translatedDayOfWeek = "Събота";
                    break;
                case "sunday":
                    translatedDayOfWeek = "Неделя";
                    break;
            }

            return translatedDayOfWeek;
        }
    }
}
