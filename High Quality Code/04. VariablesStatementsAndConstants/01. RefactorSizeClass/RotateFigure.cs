using System;

namespace RefactorSizeClass
{
    public class RotateFigure
    {
        public static Size GetRotatedSize(Size figureSize, double angleToRotate)
        {
            double angleCosinus = Math.Abs(Math.Cos(angleToRotate));
            double angleSinus = Math.Abs(Math.Sin(angleToRotate));

            double rotatedFigureWidth = (angleCosinus * figureSize.Width) + (angleSinus * figureSize.Height);
            double rotatedFigureHeight = (angleSinus * figureSize.Width) + (angleCosinus * figureSize.Height);

            Size rotatedFigure = new Size(rotatedFigureWidth, rotatedFigureHeight);
            return rotatedFigure;
        }

        static void Main()
        {
        }
    }
}