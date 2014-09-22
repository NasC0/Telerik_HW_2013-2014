/* 6. Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots). */

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
            Console.WriteLine("The equation has only one root, which is: {0}", root);
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
