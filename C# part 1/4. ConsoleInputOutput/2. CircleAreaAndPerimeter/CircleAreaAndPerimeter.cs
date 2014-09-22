/* 2. Write a program that reads the radius r of a circle and prints its perimeter and area. */

using System;

class CircleAreaAndPerimeter
{
    static void Main()
    {
        double circleRadius;
        double.TryParse(Console.ReadLine(), out circleRadius);

        double circleArea = 3.14 * (circleRadius * circleRadius);
        double circleCircumference = (3.14 * circleRadius) * 2;

        Console.WriteLine("The circle area is: {0:F2}", circleArea);
        Console.WriteLine("The circle perimeter is: {0:F2}", circleCircumference);
    }
}