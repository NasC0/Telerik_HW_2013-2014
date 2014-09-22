/* 6. Write a program that enters the coefficients a, b and c of a quadratic equation
		a*x2 + b*x + c = 0
		and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots. */

using System;
class SolveQuadraticEquation
{
    static void Main()
    {
        double numberA, numberB, numberC;
        Console.WriteLine("Please enter a, b and c of the equation: ");
        double.TryParse(Console.ReadLine(), out numberA);
        double.TryParse(Console.ReadLine(), out numberB);
        double.TryParse(Console.ReadLine(), out numberC);

        double discriminant = (numberB * numberB) - (4 * numberA * numberC);
        if (discriminant < 0)
        {
            Console.WriteLine("The equation has no real roots!");
        }
        else if (discriminant == 0)
        {
            double root = -(numberB / (2 * numberA));
        }
        else
        {
            double firstRoot = (-numberB + Math.Sqrt(discriminant)) / (2 * numberA);
            double secondRoot = (-numberB - Math.Sqrt(discriminant)) / (2 * numberA);

            Console.WriteLine("First root: {0}", firstRoot);
            Console.WriteLine("Second root: {0}", secondRoot);
        }
    }
}
