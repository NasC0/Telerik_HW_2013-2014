using System;

namespace SchoolTest
{
    public class Student
    {
        const int MinStudentID = 10000;
        const int MaxStudentID = 99999;
        private static int currentID = 10000;

        private string name;
        private int id;

        public Student(string name)
        {
            this.Name = name;
            this.ID = currentID;
            currentID++;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Student name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (value < MinStudentID || value > MaxStudentID)
                {
                    throw new ArgumentException("Student ID must be in the range [10000 ... 99999].");
                }

                this.id = value;
            }
        }
    }
}
