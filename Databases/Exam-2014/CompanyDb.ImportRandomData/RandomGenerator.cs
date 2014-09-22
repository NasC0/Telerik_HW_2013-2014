using System;
using System.Text;

namespace CompanyDb.ImportRandomData
{
    public class RandomGenerator
    {
        private const int MinCharCode = 97;
        private const int MaxCharCode = 123;
        private const string MinDate = "1990-01-01";
        private const string MaxDate = "2010-01-01";

        private static readonly DateTime MaxEndate = DateTime.Now;

        private Random randomGeneratorInstance;

        public RandomGenerator(Random generatorInstance)
        {
            this.randomGeneratorInstance = generatorInstance;
        }

        public string GetRandomString(int minLength, int maxLength)
        {
            int stringLength = this.randomGeneratorInstance.Next(minLength, maxLength + 1);
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < stringLength; i++)
            {
                int charCode = this.randomGeneratorInstance.Next(MinCharCode, MaxCharCode);
                char currentChar = (char)charCode;
                if (charCode % 2 == 0)
                {
                    currentChar = Char.ToUpper(currentChar);
                }

                resultString.Append(currentChar);
            }

            return resultString.ToString();
        }

        public int GetRandomNumber(int minValue, int maxValue)
        {
            return this.randomGeneratorInstance.Next(minValue, maxValue + 1);
        }

        public DateTime GetRandomDateRange()
        {
            var parsedMinDate = DateTime.Parse(MinDate);
            var parsedMaxDate = DateTime.Parse(MaxDate);

            var timespan = parsedMaxDate - parsedMinDate;
            var newTimespan = new TimeSpan(0, this.randomGeneratorInstance.Next(0, (int)timespan.TotalMinutes), 0);
            return parsedMinDate + newTimespan;
        }

        public DateTime GetRandomDateRange(DateTime minDate)
        {
            var timespan = MaxEndate - minDate;

            var newSpan = new TimeSpan(0, this.randomGeneratorInstance.Next(0, (int)timespan.TotalMinutes), 0);

            return minDate + newSpan;
        }
    }
}
