/* Task 1. Define two new classes Triangle and Rectangle that implement the virtual method 
 * and return the surface of the figure (width * height for the rectangle) */

namespace ShapesLibrary
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            :base(width, height)
        {
            
        }

        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }
}
