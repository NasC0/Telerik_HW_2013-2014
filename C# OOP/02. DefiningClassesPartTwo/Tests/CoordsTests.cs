using CoordsClassesAndStructs.Common;
using System;

namespace Tests
{
    class CoordsTests
    {
        static Random randomGen = new Random();

        static void Main(string[] args)
        {
            Point3D start = Point3D.CoordStart;
            Console.WriteLine("Coord Start: {0}", start);

            Point3D propertiesTest = new Point3D();
            propertiesTest.X = randomGen.Next(int.MinValue, int.MaxValue);
            propertiesTest.Y = randomGen.Next(int.MinValue, int.MaxValue);
            propertiesTest.Z = randomGen.Next(int.MinValue, int.MaxValue);
            Console.WriteLine("Properties test: {0}", propertiesTest);

            Point3D constructorTest = new Point3D(randomGen.Next(int.MinValue, int.MaxValue), randomGen.Next(int.MinValue, int.MaxValue), randomGen.Next(int.MinValue, int.MaxValue));
            Console.WriteLine("Constructor test: {0}", constructorTest);

            Console.WriteLine("Distance between points: {0}", PlaneCalculations.DistanceBetweenTwoPoints(constructorTest, propertiesTest));

            Console.WriteLine();
            Console.WriteLine("Paths saving and loading");

            Path path = new Path();
            int pointsToAdd = randomGen.Next(1, 16);
            for (int i = 0; i < pointsToAdd; i++)
            {
                path.AddPoint(new Point3D(randomGen.Next(int.MinValue, int.MaxValue), randomGen.Next(int.MinValue, int.MaxValue), randomGen.Next(int.MinValue, int.MaxValue)));
            }

            PathStorage.SavePath(path);

            var secondPath = PathStorage.LoadPath();
            Console.WriteLine(secondPath);
        }
    }
}
