using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Teacher : WorldObject, ITeacher
    {
        private List<ICourse> teacherCourses;

        public Teacher(string name)
            :base(name)
        {
            this.teacherCourses = new List<ICourse>();
        }

        public void AddCourse(ICourse course)
        {
            this.teacherCourses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("Teacher: Name={0}", this.Name);

            if (this.teacherCourses.Count > 0)
            {
                result.Append("; Courses=[");
                foreach (var course in this.teacherCourses)
                {
                    result.AppendFormat("{0}, ", course.Name);
                }

                result.Remove(result.Length - 2, 2);
                result.Append("]");
            }

            return result.ToString();
        }
    }
}
