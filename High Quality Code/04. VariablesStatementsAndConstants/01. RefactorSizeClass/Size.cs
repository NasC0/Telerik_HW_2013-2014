using System;

namespace RefactorSizeClass
{
    public class Size
    {
        private double width;

        private double height;

        public Size(double width, double height)
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
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Width value cannot be null.");
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
                if (value == null)
                {
                    throw new ArgumentNullException("Height value cannot be null.");
                }

                this.height = value;
            }
        }
    }
}
