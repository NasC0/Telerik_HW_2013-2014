/* 04. Write methods that calculate the surface of a triangle by given:
Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math. */

using System;

class TriangleSurface
{
    static void Main()
    {
        int choice;
        Console.WriteLine("Enter your choice for surface calculation");
        Console.WriteLine("1 for three sides");
        Console.WriteLine("2 for two sides and an angle between them");
        Console.WriteLine("3 for Side and an altitude to it");
        int.TryParse(Console.ReadLine(), out choice);
        if (choice == 1)
        {
            int firstSide, secondSide, thirdSide;
            Console.WriteLine("Enter the first, second and third sides:");
            int.TryParse(Console.ReadLine(), out firstSide);
            int.TryParse(Console.ReadLine(), out secondSide);
            int.TryParse(Console.ReadLine(), out thirdSide);

            int perimeter = (firstSide + secondSide + thirdSide) / 2;
            double area = Math.Sqrt(perimeter * (perimeter - firstSide) * (perimeter - secondSide) * (perimeter - thirdSide));
            Console.WriteLine(area);
        }
        else if (choice == 2)
        {
            int firstSide, secondSide, angle;
            Console.WriteLine("Enter the first and second sides and the angle between them");
            int.TryParse(Console.ReadLine(), out firstSide);
            int.TryParse(Console.ReadLine(), out secondSide);
            int.TryParse(Console.ReadLine(), out angle);

            double area = (firstSide * secondSide * Math.Sin(angle) / 2);
            Console.WriteLine(area);
        }
        else if (choice == 3)
        {

            int firstSide, sideHeight;
            Console.WriteLine("Enter the side and the height to it");
            int.TryParse(Console.ReadLine(), out firstSide);
            int.TryParse(Console.ReadLine(), out sideHeight);

            double area = (sideHeight * firstSide) / 2;
            Console.WriteLine(area);
        }
        else
        {
            Console.WriteLine("Please make a valid selection");
        }
    }
}
