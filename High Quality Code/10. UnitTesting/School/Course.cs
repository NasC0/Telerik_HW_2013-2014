using System;
using System.Collections.Generic;

namespace SchoolTest
{
    public class Course
    {
        const int MaxStudentCount = 29;

        private string name;
        private List<Student> studentList;

        public Course(string name)
        {
            this.Name = name;
            this.StudentList = new List<Student>();
        }
        public Course(string name, List<Student> studentList)
            :this(name)
        {
            this.StudentList = studentList;
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
                    throw new ArgumentNullException("Course name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public List<Student> StudentList
        {
            get
            {
                return new List<Student>(this.studentList);
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Student list cannot be null");
                }

                this.studentList = value;
            }
        }

        public void AddStudent(Student studentToAdd)
        {
            if (!this.studentList.Contains(studentToAdd))
            {
                if (this.studentList.Count >= MaxStudentCount)
                {
                    throw new InvalidOperationException("Course student limit reached.");
                }

                this.studentList.Add(studentToAdd);
            }
        }

        public void RemoveStudent(Student studentToRemove)
        {
            if (this.studentList.Contains(studentToRemove))
            {
                this.studentList.Remove(studentToRemove);
            }
        }
    }
}
