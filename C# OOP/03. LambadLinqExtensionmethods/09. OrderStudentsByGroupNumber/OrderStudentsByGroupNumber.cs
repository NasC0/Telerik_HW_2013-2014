/* Task 9. Create a List<Student> with sample students. Select only the students that are from group number 2. 
 * Use LINQ query. Order the students by FirstName. */

/* Task 10. Implement the previous using the same query expressed with extension methods. */

/* Task 11. Extract all students that have email in abv.bg. Use string methods and LINQ. */

/* Task 12. Extract all students with phones in Sofia. Use LINQ. */

namespace _09.OrderStudentsByGroupNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Student.Common;

    class OrderStudentsByGroupNumber
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Leeroy", "Jenkins", "F1231", "0882 64 32 12", "Maimuna@abv.bg", 2));
            students.Add(new Student("Shatmi", "Shmatev", "FShmatio", "02 SHMATKA 500", "Shmatka@gmail.com", 1));
            students.Add(new Student("Pesho", "Peshev", "12315", "02 123 456", "Peshkata@gmail.bg", 2));
            students.Add(new Student("Gosho", "Georgiev", "987123", "01231354", "Taratanci@abv.bg", 2));

            students[0].Marks.AddRange(new List<int>() { 2, 3, 4, 5, 6, 2 });
            students[1].Marks.AddRange(new List<int>() { 2, 2, 3, 4, 5, 6, 2 });
            students[2].Marks.AddRange(new List<int>() { 3, 1, 3, 4, 5, 1 });
            students[3].Marks.AddRange(new List<int>() { 6 });

            #region Task 9.
            Console.WriteLine("Task 9: Students only from group 2; LINQ\n");

            var linqSelectedStudents = from student in students
                                   where student.Groupnumber == 2
                                   orderby student.FirstName
                                   select student;

            foreach (var student in linqSelectedStudents)
            {
                Console.WriteLine(student);
            }

            #endregion

            #region Task 10.

            Console.WriteLine("\nTask 10: Students from group 2; Lambda\n");
            var lambdaSelectedStudents = students.Where(x => x.Groupnumber == 2).OrderBy(x => x.FirstName);

            foreach (var student in lambdaSelectedStudents)
            {
                Console.WriteLine(student);
            }
            
            #endregion

            #region Task 11. 

            Console.WriteLine("\nTask 11: Students with email in abv.bg\n");
            
            var extractedEmails = from student in students
                                  where student.EmailAddress.Contains("@abv.bg")
                                  select student;

            foreach (var studente in extractedEmails)
            {
                Console.WriteLine(studente);
            }

            #endregion

            #region Task 12.

            Console.WriteLine("\nTask 12: Students with phones in Sofia\n");

            var extractedPhones = from student in students
                                  where student.TelephoneNumber.Substring(0, 2) == "02"
                                  select student;

            foreach (var student in extractedPhones)
            {
                Console.WriteLine(student);
            }
            
            #endregion
        }
    }
}
