using System;

namespace Methods
{
    class Methods
    {
        static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }
            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentException("Invalid number.");
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("The input elements must not be null or empty.");
            }

            var maxElement = int.MinValue;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }
            return maxElement;
        }

        static void PrintAsNumber(object number, FormattingOptions format)
        {
            if (format == FormattingOptions.RoundNumber)
            {
                Console.WriteLine("{0:f2}", number);
            }
            if (format == FormattingOptions.ConvertDoubleToPercent)
            {
                Console.WriteLine("{0:p0}", number);
            }
            if (format == FormattingOptions.PadRight)
            {
                Console.WriteLine("{0,8}", number);
            }
        }


        static double CalculateDistance(double xPointFrom, double yPointFrom, double xPointTo, double yPointTo, 
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (yPointFrom == yPointTo);
            isVertical = (xPointFrom == xPointTo);

            double firstSquare = (xPointTo - xPointFrom) * (xPointTo - xPointFrom);
            double secondSquare = (yPointTo - yPointFrom) * (yPointTo - yPointFrom);

            double distance = Math.Sqrt(firstSquare + secondSquare);
            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, FormattingOptions.RoundNumber);
            PrintAsNumber(0.75, FormattingOptions.ConvertDoubleToPercent);
            PrintAsNumber(2.30, FormattingOptions.PadRight);

            bool horizontal, vertical;
            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";
            int currentYear = DateTime.Now.Year;
            peter.Age = currentYear - 1992;

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";
            stella.Age = currentYear - 1993;

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
