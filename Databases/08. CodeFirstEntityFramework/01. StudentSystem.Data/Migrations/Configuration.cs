namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        private const int MinRandomCount = 5;
        private const int MaxRandomCount = 100;
        private const int MinNameLength = 5;
        private const int MaxNameLength = 100;
        private const int FacultyNumberLength = 6;
        private const int AsciiLetterStart = 97;
        private const int AsciiLetterEnd = 123;
        private const string Description = "Lorem ipsum sit dolor amet.";

        private static Random randomGenerator = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        // Task 03. Seed the data with random values
        protected override void Seed(StudentSystemDbContext context)
        {
            if (context.Homeworks.Count() > 0 || context.Courses.Count() > 0|| context.Students.Count() > 0)
            {
                return;
            }

            var students = this.SeedStudents();
            var courses = this.SeedCourses(students);
            var homeworks = this.SeedHomeworks(courses, students);

            context.Students.AddOrUpdate(students);
            context.Courses.AddOrUpdate(courses);
            context.Homeworks.AddOrUpdate(homeworks);
        }

        private Student[] SeedStudents()
        {
            int randomStudentCount = randomGenerator.Next(MinRandomCount, MaxRandomCount);
            var students = new Student[randomStudentCount];

            for (int i = 0; i < randomStudentCount; i++)
            {
                string currentRandomName = this.RandomString();
                string currentFacultyNumber = this.RandomFacultyNumber();
                var currentStudent = new Student()
                {
                    Name = currentRandomName,
                    FNumber = currentFacultyNumber
                };

                students[i] = currentStudent;
            }

            return students;
        }

        private Course[] SeedCourses(Student[] seededStudents)
        {
            int randomCourseCount = randomGenerator.Next(MinRandomCount, MaxRandomCount);
            var courses = new Course[randomCourseCount];

            for (int i = 0; i < randomCourseCount; i++)
            {
                string randomCourseName = this.RandomString();
                var course = new Course()
                {
                    Name = randomCourseName,
                    Description = Description
                };

                courses[i] = course;

                int attachRandomStudents = randomGenerator.Next(0, seededStudents.Length / 2);
                for (int j = 0; j < attachRandomStudents; j++)
                {
                    int studentIndex = randomGenerator.Next(0, seededStudents.Length);
                    var selectedStudent = seededStudents[studentIndex];

                    while (course.Students.Contains(selectedStudent))
                    {
                        studentIndex = randomGenerator.Next(0, seededStudents.Length);
                        selectedStudent = seededStudents[studentIndex];
                    }

                    course.Students.Add(selectedStudent);
                }
            }

            return courses;
        }

        private Homework[] SeedHomeworks(Course[] seededCourses, Student[] seededStudents)
        {
            int homeworkCount = randomGenerator.Next(MinRandomCount, MaxRandomCount);
            var homeworks = new Homework[homeworkCount];

            for (int i = 0; i < homeworkCount; i++)
            {
                string randomContent = RandomString();
                var currentHomework = new Homework()
                {
                    Content = randomContent
                };

                homeworks[i] = currentHomework;
                int randomCourseIndex = randomGenerator.Next(0, seededCourses.Length);
                int randomStudentIndex = randomGenerator.Next(0, seededStudents.Length);

                currentHomework.Course = seededCourses[randomCourseIndex];
                currentHomework.Student = seededStudents[randomStudentIndex];
            }

            return homeworks;
        }

        private string RandomString()
        {
            StringBuilder randomName = new StringBuilder();
            int nameLength = randomGenerator.Next(MinNameLength, MaxNameLength);
            for (int i = 0; i < nameLength; i++)
            {
                int letterCode = randomGenerator.Next(AsciiLetterStart, AsciiLetterEnd);
                char letter = (char)letterCode;

                if (letterCode % 2 == 0)
                {
                    letter = Char.ToUpper(letter);
                }

                randomName.Append(letter);
            }

            return randomName.ToString();
        }

        private string RandomFacultyNumber()
        {
            StringBuilder randomFacultyNumber = new StringBuilder();
            randomFacultyNumber.Append('F');
            for (int i = 1; i < FacultyNumberLength; i++)
            {
                int digit = randomGenerator.Next(0, 10);

                randomFacultyNumber.Append(digit);
            }

            return randomFacultyNumber.ToString();
        }
    }
}
