// 01. In the school there are classes of students.

namespace SchoolClasses
{
    using System.Collections.Generic;

    public class School
    {
        public School()
            : this(new List<SchoolClass>())
        {
        }

        public School(List<SchoolClass> classes)
        {
            this.Classes = classes;
        }

        public List<SchoolClass> Classes { get; private set; }

        public void AddClass(SchoolClass toAdd)
        {
            this.Classes.Add(toAdd);
        }
    }
}
