/* 2. Which of the following values can be assigned to a variable of type float and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091? */
using System;

class FloatAndDouble
{
    static void Main()
    {
        // All values can be assigned to double
        double dblFirst = 34.567839023;
        double dblSecond = 12.345;
        double dblThird = 8923.1234857;
        double dblFourth = 3456.091;

        Console.WriteLine("{0}, {1}, {2}, {3}", dblFirst, dblSecond, dblThird, dblFourth);

        // However, float is too small to hold the first and the third of these values;
        float fltFirst = 34.567839023f;
        float fltSecond = 12.345f;
        float fltThird = 8923.1234857f;
        float fltFourth = 3456.091f;

        Console.WriteLine("{0}, {1}, {2}, {3}", fltFirst, fltSecond, fltThird, fltFourth);
    }
}
