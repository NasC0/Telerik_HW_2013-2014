/* Task 1. Define class Circle and suitable constructor so that at initialization 
 * height must be kept equal to width and implement the CalculateSurface() method. */

namespace ShapesLibrary
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        
        public abstract double CalculateSurface();

        public double Width
        {
            get
            {
                return this.width;
            }
            protected set
            {
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                this.height = value;
            }
        }
    }
}
