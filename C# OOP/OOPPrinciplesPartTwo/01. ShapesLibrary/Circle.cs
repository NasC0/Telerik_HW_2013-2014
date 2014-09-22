

namespace ShapesLibrary
{
    public class Circle : Shape
    {
        public Circle(double radius)
            :base(radius, radius)
        {
        }

        public override double CalculateSurface()
        {
            return System.Math.PI * (this.Width * this.Height);
        }
    }
}
