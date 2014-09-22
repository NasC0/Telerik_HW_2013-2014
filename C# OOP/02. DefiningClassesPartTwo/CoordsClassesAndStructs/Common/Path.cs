/* Task 4. Create a class Path to hold a sequence of points in the 3D space.  */

namespace CoordsClassesAndStructs.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Path
    {
        public List<Point3D> PathList { get; private set; }

        public Path()
        {
            this.PathList = new List<Point3D>();
        }

        public void AddPoint(Point3D pointToAdd)
        {
            this.PathList.Add(pointToAdd);
        }

        public override string ToString()
        {
            StringBuilder appendedPoints = new StringBuilder();

            for (int i = 0; i < this.PathList.Count; i++)
            {
                if (i != this.PathList.Count - 1)
                {
                    appendedPoints.AppendLine(this.PathList[i].ToString());
                }
                else
                {
                    appendedPoints.Append(this.PathList[i]);
                }
            }

            return appendedPoints.ToString();
        }
    }
}
