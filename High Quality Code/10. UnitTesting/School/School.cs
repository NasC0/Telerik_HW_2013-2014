using System;
using System.Collections.Generic;

namespace SchoolTest
{
    public class School
    {
        private string name;
        private List<Course> courses;

        public School(string name)
        {
            this.Name = name;
            this.Courses = new List<Course>();
        }

        public School(string name, List<Course> courses)
            :this(name)
        {
            this.Courses = courses;
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
                    throw new ArgumentNullException("School name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public List<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course list cannot be null");
                }

                this.courses = value;
            }
        }

        public void AddCourse(Course courseToAdd)
        {
            if (!this.courses.Contains(courseToAdd))
            {
                this.courses.Add(courseToAdd);
            }
        }

        public void RemoveCourse(Course courseToRemove)
        {
            if(this.courses.Contains(courseToRemove))
            {
                this.courses.Remove(courseToRemove);
            }
        }
    }
}
