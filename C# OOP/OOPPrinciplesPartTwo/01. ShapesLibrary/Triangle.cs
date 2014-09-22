/* Task 1. Define two new classes Triangle and Rectangle that implement the virtual method 
 * and return the surface of the figure (height * width / 2 for the rectangle). */

namespace ShapesLibrary
{
    public class Triangle : Shape
    {
        public Triangle(double width, double height)
            :base(width, height)
        {
            
        }

        public override double CalculateSurface()
        {
            return (this.Width * this.Height) / 2;
        }
    }
}
