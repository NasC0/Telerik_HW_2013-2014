/* Task 2. Define new class Student which is derived from Human and has new field – grade. */

namespace StudentsAndWorkers
{
    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName)
            : this(firstName, lastName, 0)
        {
        }

        public Student(string firstName, string lastName, int grades)
            : base(firstName, lastName)
        {
            this.Grade = grades;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Grade: {1}", base.ToString(), this.Grade);
        }
    }
}
