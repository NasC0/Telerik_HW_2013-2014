using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileOperationUtils.GetFileExtension("example"));
            Console.WriteLine(FileOperationUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileOperationUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileOperationUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileOperationUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileOperationUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                ThreeDimensionalOperationsUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                ThreeDimensionalOperationsUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            var threeDFigure = new ThreeDimensionalObject(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", 
                ThreeDimensionalOperationsUtils.CalcVolume(threeDFigure));
            Console.WriteLine("Diagonal XYZ = {0:f2}", 
                ThreeDimensionalOperationsUtils.CalcDiagonalXYZ(threeDFigure));
            Console.WriteLine("Diagonal XY = {0:f2}", 
                ThreeDimensionalOperationsUtils.CalcDiagonalXY(threeDFigure));
            Console.WriteLine("Diagonal XZ = {0:f2}", 
                ThreeDimensionalOperationsUtils.CalcDiagonalXZ(threeDFigure));
            Console.WriteLine("Diagonal YZ = {0:f2}", 
                ThreeDimensionalOperationsUtils.CalcDiagonalYZ(threeDFigure));
        }
    }
}
