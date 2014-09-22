/* Task 1. Write a program that tests the behavior of  the CalculateSurface() 
 * method for different shapes (Circle, Rectangle, Triangle) stored in an array. */

using System;
using System.Collections.Generic;
using ShapesLibrary;

class ShapesTest
{
    static void Main()
    {
        Shape[] shapesList = new Shape[]
        {
            new Rectangle(10, 5),
            new Triangle(5, 5),
            new Circle(3.10)
        };

        Console.WriteLine("Rectangle area: {0}", shapesList[0].CalculateSurface());
        Console.WriteLine("Triangle area: {0}", shapesList[1].CalculateSurface());
        Console.WriteLine("Circle area: {0}", shapesList[2].CalculateSurface());
    }
}
