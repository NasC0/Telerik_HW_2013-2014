/* Task 02. Define abstract class Human with first name and last name. 
 * Define new class Student which is derived from Human and has new field – grade. 
 * Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() 
 * that returns money earned by hour by the worker. Define the proper constructors and properties for this hierarchy. 
 * Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method). 
 * Initialize a list of 10 workers and sort them by money per hour in descending order. 
 * Merge the lists and sort them by first name and last name. */

namespace _02.StudentsAndWorkersTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StudentsAndWorkers;

    public class StudentsAndWorkersTest
    {
        public static void Main()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student("John", "Doe", 2),
                new Student("Maria", "Peneva", 6),
                new Student("Petko", "Petrov", 4),
                new Student("Sandokan", "Sdvatanoja", 0),
                new Student("Izcherpah", "Si", 4),
                new Student("Kreativnite", "Imena", 2),
                new Student("Random", "Name", 3),
                new Student("Another", "Random", 6),
                new Student("New", "One", 3),
                new Student("Last", "One", 1)
            };

            studentList = studentList.OrderBy(x => x.Grade).ToList();

            Console.WriteLine("Students: \n");
            foreach (var student in studentList)
            {
                Console.WriteLine(student);
            }

            List<Worker> workerList = new List<Worker>()
            {
                new Worker("Wallace", "Sanchez", 350, 8),
                new Worker("Samantha", "Patterson", 500, 10),
                new Worker("Vivian", "Mann", 400, 5),
                new Worker("Casey", "Roy", 1000, 12),
                new Worker("Pat", "Bowman", 320, 4),
                new Worker("Ruth", "Long", 100, 1),
                new Worker("Rafael", "Copeland", 600, 9),
                new Worker("Timmy", "Barton", 490, 10),
                new Worker("Salvatore", "Lowe", 670, 8),
                new Worker("Russell", "Powell", 1500, 13)
            };

            workerList = workerList.OrderByDescending(x => x.MoneyPerHour()).ToList();

            Console.WriteLine("\nWorkers: \n");
            foreach (var worker in workerList)
            {
                Console.WriteLine(worker);
            }

            List<Human> humansList = new List<Human>();
            humansList.AddRange(studentList);
            humansList.AddRange(workerList);

            humansList = humansList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

            Console.WriteLine("\nMerged lists: \n");
            foreach (var human in humansList)
            {
                Console.WriteLine(human);
            }
        }
    }
}
