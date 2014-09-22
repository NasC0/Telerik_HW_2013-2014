using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SchoolTest
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolConstructorTestName()
        {
            string schoolName = "Ivan Vazov";
            School testSchools = new School(schoolName);
            Assert.AreEqual(schoolName, testSchools.Name);
        }

        [TestMethod]
        public void SchoolConstructorTestNameWithList()
        {
            string schoolName = "Ivan Vazov";
            var courseList = new List<Course>();
            School testSchools = new School(schoolName, courseList);
            Assert.AreEqual(schoolName, testSchools.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolConstructorTestNullName()
        {
            new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolConstrucotrTestEmptyName()
        {
            new School(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolConstrucotrTestWhiteSpaceName()
        {
            new School("    ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolConstructorTestNullList()
        {
            string schoolName = "Math";
            List<Course> courseList = null;
            School testCourse = new School(schoolName, courseList);
        }

        [TestMethod]
        public void SchoolAddCourseTest()
        {
            Course course = new Course("Math");
            School testSchool = new School("Ivan Vazov");
            testSchool.AddCourse(course);
            Assert.IsTrue(testSchool.Courses.Count == 1);
            Assert.AreEqual(course, testSchool.Courses[0]);
        }

        [TestMethod]
        public void SchoolRemoveCourseTest()
        {
            Course course = new Course("Math");
            School testSchool = new School("Ivan Vazov");
            testSchool.AddCourse(course);
            Assert.IsTrue(testSchool.Courses.Count == 1);
            testSchool.RemoveCourse(course);
            Assert.IsTrue(testSchool.Courses.Count == 0);
        }
    }
}
