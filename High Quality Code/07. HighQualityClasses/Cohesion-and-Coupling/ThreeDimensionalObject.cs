using System;

namespace CohesionAndCoupling
{
    public class ThreeDimensionalObject
    {
        private double width;
        private double height;
        private double depth;

        public ThreeDimensionalObject(double objectWidth, double objectHeight, double objectDepth)
        {
            this.Width = objectWidth;
            this.Height = objectHeight;
            this.Depth = objectDepth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("3D object width cannot be negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("3D object height cannot be negative.");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("3D object depth cannot be negative.");
                }

                this.depth = value;
            }
        }
    }
}
