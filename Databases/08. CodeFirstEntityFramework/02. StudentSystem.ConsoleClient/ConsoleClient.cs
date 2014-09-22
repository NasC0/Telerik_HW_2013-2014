<<<<<<< HEAD
﻿// Task 02. Write a console application that uses the data
=======
﻿
// Task 02. Write a console application that uses the data
>>>>>>> origin/master

using System.Collections.Generic;
using System.Linq;

using StudentSystem.Data;
using StudentSystem.Model;

namespace StudentSystem.ConsoleClient
{
    public class ConsoleClient
    {
        public static Student AddStudent(IStudentSystemData dataProvider, string name, string facultyNumber,
            IEnumerable<Course> courses = null, IEnumerable<Homework> homeworks = null)
        {
            var student = new Student()
            {
                Name = name,
                FNumber = facultyNumber
            };

            if (courses != null)
            {
                foreach (var course in courses)
                {
                    student.Courses.Add(course);
                }
            }

            if (homeworks != null)
            {
                foreach (var homework in homeworks)
                {
                    student.Homeworks.Add(homework);
                }
            }

            dataProvider.Students.Add(student);
            dataProvider.SaveChanges();

            return student;
        }

        public static void Main()
        {
            StudentSystemData dataProvider = new StudentSystemData();
            string studentName = "Mitio Pishtova";
<<<<<<< HEAD
            string fNumber = "F92117";
=======
            string fNumber = "F98517";
>>>>>>> origin/master

            var courses = dataProvider.Courses.GetAll().Take(5);

            AddStudent(dataProvider, studentName, fNumber, courses);
<<<<<<< HEAD

            dataProvider.Homeworks.Add(new Homework()
                {
                    Content = "awkljdalwkjd",
                    Course = new Course()
                    {
                        Name = "Test course",
                        Description = "Test course"
                    },
                    Student = new Student()
                    {
                        Name = "Jlkwjalksjd",
                        FNumber = "F12398"
                    }
                });
=======
>>>>>>> origin/master
        }
    }
}
