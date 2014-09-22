/* Task 01. We are given a school. In the school there are classes of students. Each class has a set of teachers. 
 * Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have unique text identifier. 
 * Teachers have name. Disciplines have name, number of lectures and number of exercises. Both teachers and students are people. 
 * Students, classes, teachers and disciplines could have optional comments (free text block). 
 * 
 * Your task is to identify the classes (in terms of  OOP) and their attributes and operations, 
 * encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio. */

namespace _01.SchoolClassesTest
{
    using System;
    using System.Collections.Generic;
    using SchoolClasses;

    public class SchoolClassesTest
    {
        public static void Main()
        {
            // Define some Disciplines
            Discipline math = new Discipline("Mathematics", 15, 15);
            math.Comment = "Math class";
            Discipline biology = new Discipline("Biology", 20, 10);
            Discipline literature = new Discipline("Literature", 30, 0);
            Discipline chemistry = new Discipline("Chemistry", 10, 20);
            Discipline physics = new Discipline("Physics", 15, 15);

            // Define some Teachers
            Teacher mathTeacher = new Teacher("Ruska Ilieva", 
                new List<Discipline>() 
                { 
                    math, 
                    physics
                });

            mathTeacher.Comment = "The nemesis of all freshman students.";

            Teacher appliedSciencesTeacher = new Teacher("Galia Gancheva", new List<Discipline>() 
            { 
                physics, 
                chemistry
            });

            appliedSciencesTeacher.Comment = "Pretty easy-going";

            Teacher biologyTeacher = new Teacher("Kristina Spasova", new List<Discipline>() { biology });

            biologyTeacher.Comment = "Loves to crack jokes and pull students' legs";

            Teacher literatureTeacher = new Teacher("Dobrina Topalova", new List<Discipline>() { literature });

            literatureTeacher.Comment = "Used to drink vodka in the bathroom stalls";

            // Define some Students
            Student firstClassStudentOne = new Student("Some Student", 1);
            Student firstClassStudentTwo = new Student("Another Student", 2);
            Student firstClassStudentThree = new Student("Yet Another", 3);

            Student secondClassStudentOne = new Student("Random Student", 1);
            Student secondClassStudentTwo = new Student("Another Random", 2);
            Student secondClassStudentThree = new Student("Randomly Random", 3);

            // Define some CLasses
            SchoolClass classOne = new SchoolClass("12 A", new List<Student>()
            {
                firstClassStudentOne,
                firstClassStudentTwo,
                firstClassStudentThree
            }, new List<Teacher>()
                {
                    mathTeacher,
                    biologyTeacher
                });

            classOne.Comment = "The \"rocket science\" class of the school";

            SchoolClass classTwo = new SchoolClass("12 B", new List<Student>()
            {
                secondClassStudentOne,
                secondClassStudentTwo,
                secondClassStudentThree
            }, new List<Teacher>()
               {
                   appliedSciencesTeacher,
                   literatureTeacher
               });

            // Define a School
            School randomSchool = new School(new List<SchoolClass>()
            {
                classOne,
                classTwo
            });

            // Iterate over schools
            foreach (var studentClass in randomSchool.Classes)
            {
                Console.WriteLine("Current class: {0}", studentClass.ClassID);
                if (studentClass.Comment != string.Empty)
                {
                    Console.WriteLine(studentClass.Comment);
                }

                Console.WriteLine("Students: ");
                foreach (var student in studentClass.Students)
                {
                    Console.WriteLine(student);

                    if (student.Comment != string.Empty)
                    {
                        Console.WriteLine(student.Comment);
                    }
                }

                Console.WriteLine("Teachers: ");
                foreach (var teacher in studentClass.Teachers)
                {
                    Console.WriteLine(teacher.ToString());

                    if (teacher.Comment != string.Empty)
                    {
                        Console.WriteLine(teacher.Comment);
                    }

                    Console.WriteLine("Teacher classes: ");

                    foreach (var discipline in teacher.DisciplinesTaught)
                    {
                        Console.WriteLine(discipline);
                        if (discipline.Comment != string.Empty)
                        {
                            Console.WriteLine(discipline.Comment);
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
