/* Task 3. Write a static class with a static method to calculate the distance between two points in the 3D space. */

namespace CoordsClassesAndStructs.Common
{
    using System;
    public static class PlaneCalculations
    {
        public static double DistanceBetweenTwoPoints(Point3D firstPoint, Point3D secondPoint)
        {
            int xPointCalc = secondPoint.X - firstPoint.X;
            int yPointCalc = secondPoint.Y - firstPoint.Y;
            int zPointCalc = secondPoint.Z - firstPoint.Z;

            return Math.Sqrt((xPointCalc * xPointCalc) + (yPointCalc * yPointCalc) + (zPointCalc * zPointCalc));
        }
    }
}
