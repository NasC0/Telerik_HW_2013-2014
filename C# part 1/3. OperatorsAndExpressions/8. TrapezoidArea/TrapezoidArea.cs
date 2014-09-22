/* 8. Write an expression that calculates trapezoid's area by given sides a and b and height h. */

using System;

class TrapezoidArea
{
    static void Main()
    {
        double sideA = 5.2;
        double sideB = 2.3;
        double height = 3.4;
        double area = ((sideA + sideB) / 2) * height;
        Console.WriteLine(area);
    }
}
