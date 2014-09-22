/* Task 13. Select all students that have at least one mark Excellent (6) into a new anonymous class 
 * that has properties – FullName and Marks. Use LINQ. */

/* Task 14. Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods. */

/* Task 15. Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN). */

/* Task 16. Extract all students from "Mathematics" department. Use the Join operator. */

namespace _13_15.GroupByMarks
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Student.Common;

    class GroupByMarks
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Leeroy", "Jenkins", "123406", "0882 64 32 12", "Maimuna@abv.bg", 2, new Group(1, "Mathematics")));
            students.Add(new Student("Shatmi", "Shmatev", "FShmatio", "02 SHMATKA 500", "Shmatka@gmail.com", 1, new Group(2, "Informatics")));
            students.Add(new Student("Pesho", "Peshev", "12315", "02 123 456", "Peshkata@gmail.bg", 2, new Group(3, "Hardware")));
            students.Add(new Student("Gosho", "Georgiev", "123406", "01231354", "Taratanci@abv.bg", 2, new Group(1, "Mathematics")));

            students[0].Marks.AddRange(new List<int>() { 2, 3, 4, 5, 6, 2 });
            students[1].Marks.AddRange(new List<int>() { 2, 2, 3, 4, 5, 6, 2 });
            students[2].Marks.AddRange(new List<int>() { 3, 1, 3, 4, 5, 1 });
            students[3].Marks.AddRange(new List<int>() { 6, 2 });

            #region Task 13.

            Console.WriteLine("\nTask 13: Students with at least one mark 6\n");

            var extractExcellentMarks = from student in students
                                        from mark in student.Marks
                                        where mark == 6
                                        select new
                                        {
                                            FullName = student.FirstName + " " + student.LastName,
                                            Grades = student.Marks
                                        };

            foreach (var student in extractExcellentMarks)
            {
                Console.WriteLine(student.FullName);
            }


            #endregion

            #region Task 14.

            Console.WriteLine("\nTask 14: Students with exactly two marks 2\n");

            var twoMarksTwo = students.Where(x => x.Marks.Count(y => y == 2) == 2).Select(x => new { FullName = x.FirstName + " " + x.LastName, Marks = x.Marks });

            foreach (var student in twoMarksTwo)
            {
                Console.WriteLine(student.FullName);
            }

            #endregion

            #region Task 15.

            Console.WriteLine("\nTask 15: Extract marks of students from 2006\n");

            var studentMarks = from student in students
                               where student.FacultyNumber.Length >= 6
                               && student.FacultyNumber.Substring(4, 2) == "06"
                               select student.Marks;

            foreach (var markList in studentMarks)
            {
                foreach (var mark in markList)
                {
                    Console.WriteLine(mark);
                }
            }

            #endregion

            Console.WriteLine("\nTask 16: Extract all students from Mathematics department\n");

            List<Group> groupsLIst = new List<Group>()
            {
                new Group(1, "Mathematics"),
                new Group(2, "Informatics"),
                new Group(3, "Hardware")
            };

            var studentsGroup = from student in students
                                join grp in groupsLIst on student.Group.DepartmentName equals grp.DepartmentName
                                where student.Group.DepartmentName == "Mathematics"
                                select new { Student = student, Group = grp };

            foreach (var student in studentsGroup)
            {
                Console.WriteLine(student.Student);
                Console.WriteLine(student.Group);
            }
        }
    }
}
