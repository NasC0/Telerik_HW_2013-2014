// 01. In the school there are classes of students. Each class has a set of teachers. Classes have unique text identifier.

namespace SchoolClasses
{
    using System.Collections.Generic;

    public class SchoolClass : WorldObject
    {
        public SchoolClass(string id)
            : this(id, new List<Student>(), new List<Teacher>())
        {
        }

        public SchoolClass(string id, List<Student> students)
            : this(id, students, new List<Teacher>())
        {
        }

        public SchoolClass(string id, List<Student> students, List<Teacher> teachers)
        {
            this.ClassID = id;
            this.Students = students;
            this.Teachers = teachers;
        }

        public string ClassID { get; protected set; }

        public List<Student> Students { get; protected set; }

        public List<Teacher> Teachers { get; protected set; }

        public void AddStudent(Student toAdd)
        {
            this.Students.Add(toAdd);
        }

        public void AddTeacher(Teacher toAdd)
        {
            this.Teachers.Add(toAdd);
        }
    }
}
