using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StudentsAndCourses
{
    public class StudentsAndCourses
    {
        public const string FileLocation = "..\\..\\students.txt";

        public static void Main()
        {
            var studentsList = new List<string>();

            using (StreamReader studentsReader = new StreamReader(FileLocation))
            {
                string currentLine = studentsReader.ReadLine();
                while (currentLine != null)
                {
                    studentsList.Add(currentLine);
                    currentLine = studentsReader.ReadLine();
                }
            }

            var studentsDict = new SortedDictionary<string, string>();

            foreach (var student in studentsList)
            {
                var splitStudent = student.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                string studentCourse = splitStudent[2];
                string studentFullName = splitStudent[0] + ' ' + splitStudent[1];

                studentsDict.Add(studentFullName, studentCourse);
            }

            var orderedDictionary = studentsDict.GroupBy(x => x.Value).OrderBy(x => x.Key);
            
            StringBuilder outputText = new StringBuilder();
            foreach (var courseEntry in orderedDictionary)
            {
                outputText.AppendFormat("{0}: ", courseEntry.Key);

                foreach (var name in courseEntry)
                {
                    outputText.AppendFormat("{0}, ", name.Key);
                }
                outputText.Remove(outputText.Length - 2, 2);
                outputText.AppendLine();
            }

            Console.WriteLine(outputText.ToString());
        }
    }
}
