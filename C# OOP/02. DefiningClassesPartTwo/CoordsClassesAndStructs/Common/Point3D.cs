/* Task 1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
 * Implement the ToString() to enable printing a 3D point. */

namespace CoordsClassesAndStructs.Common
{
    using System;

    public struct Point3D
    {
        /* Task 2. Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
         * Add a static property to return the point O. */
        private static readonly Point3D coordStart = new Point3D(0, 0, 0);

        public static Point3D CoordStart
        {
            get
            {
                return coordStart;
            }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D(int xPoint, int yPoint, int zPoint)
            :this()
        {
            this.X = xPoint;
            this.Y = yPoint;
            this.Z = zPoint;
        }

        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Z:{2}", this.X, this.Y, this.Z);
        }

    }
}
