// 01. Students have name and unique class number. Both teachers and students are people.

namespace SchoolClasses
{
    public class Student : People
    {
        public Student(string name, int classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber { get; private set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Class Number: {1}", this.Name, this.ClassNumber);
        }
    }
}
