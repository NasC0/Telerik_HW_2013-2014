using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;

namespace SchoolTest
{
    [TestClass]
    public class CourseTests
    {
        [TestInitialize]
        public void RefreshCounter()
        {
            FieldInfo refresh = typeof(Student).GetField("currentID", BindingFlags.NonPublic | BindingFlags.Static);
            refresh.SetValue(null, 10000);
        }

        [TestMethod]
        public void CourseConstructorTestName()
        {
            string courseName = "Math";
            Course testCourse = new Course(courseName);
            Assert.AreEqual(courseName, testCourse.Name);
        }

        [TestMethod]
        public void CourseConstructorTestNameWithList()
        {
            string courseName = "Math";
            var studentList = new List<Student>();
            Course testCourse = new Course(courseName, studentList);
            Assert.AreEqual(courseName, testCourse.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseConstructorTestNullName()
        {
            new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseConstrucotrTestEmptyName()
        {
            new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseConstrucotrTestWhiteSpaceName()
        {
            new Course("    ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseConstructorTestNullList()
        {
            string courseName = "Math";
            List<Student> studentList = null;
            Course testCourse = new Course(courseName, studentList);
        }

        [TestMethod]
        public void CourseAddStudentTestOneStudent()
        {
            Course course = new Course("Math");
            Student studentToAdd = new Student("Pesho Peshev");
            course.AddStudent(studentToAdd);
            Assert.IsTrue(course.StudentList.Count == 1);
        }

        [TestMethod]
        public void CourseAddStudentTestTwoStudents()
        {
            string name = "Math";
            List<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student pesho = new Student("Pesho Peshev");
            Student petar = new Student("Petar Marinov");
            course.AddStudent(pesho);
            course.AddStudent(petar);
            Assert.IsTrue(course.StudentList.Count == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseAddStudentTestMaxStudents()
        {
            Course course = new Course("Math");
            for (int i = 0; i < 40; i++)
            {
                Student currentStudent = new Student(String.Format("Student {0}", i));
                course.AddStudent(currentStudent);
            }
        }

        [TestMethod]
        public void CourseRemoveStudentTest()
        {
            Student student = new Student("Misho");
            Course course = new Course("Math");
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.IsTrue(course.StudentList.Count == 0);
        }
    }
}
