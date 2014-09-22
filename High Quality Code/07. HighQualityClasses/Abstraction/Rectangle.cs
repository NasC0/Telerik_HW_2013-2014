using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle()
        {
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Rectangle width cannot be null.");
                }
                if (value < 0)
                {
                    throw new ArgumentException("Rectangle width cannot be negative.");
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
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Rectangle height cannot be null.");
                }
                if (value < 0)
                {
                    throw new ArgumentException("Rectangle height cannot be negative.");
                }

                this.height = value;
            }
        }

        public double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
