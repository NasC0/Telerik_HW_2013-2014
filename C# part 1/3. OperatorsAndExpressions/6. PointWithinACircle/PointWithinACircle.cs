/* 6. Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0. */

using System;

class PointWithinACircle
{
    static void Main()
    {
        int xPoint = 2;
        int yPoint = 3;

        if (((xPoint - 0) * (xPoint - 0)) + ((yPoint - 0) * (yPoint - 0)) <= 5 * 5)
        {
            Console.WriteLine("The point is within the circle");
        }
        else
        {
            Console.WriteLine("The point is out of the circle");
        }
    }
}
