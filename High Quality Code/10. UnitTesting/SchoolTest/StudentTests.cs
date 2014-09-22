using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace SchoolTest
{
    [TestClass]
    public class StudentTests
    {
        [TestInitialize]
        public void RefreshCounter()
        {
            FieldInfo refresh = typeof(Student).GetField("currentID", BindingFlags.NonPublic | BindingFlags.Static);
            refresh.SetValue(null, 10000);
        }

        [TestMethod]
        public void StudentConstructorTestName()
        {
            string studentName = "Pesho Peshev";
            Student testStudent = new Student(studentName);
            Assert.AreEqual(studentName, testStudent.Name);
        }

        [TestMethod]
        public void StudentConstructorTestID()
        {
            string studentName = "Pesho Peshev";
            Student testStudent = new Student(studentName);
            Assert.AreEqual(10000, testStudent.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentConstructorTestNullName()
        {
            string studentName = null;
            Student testStudent = new Student(studentName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentConstructorTestEmptyName()
        {
            string studentName = string.Empty;
            Student testStudent = new Student(studentName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentConstructorTestWhitespaceName()
        {
            string studentName = "       ";
            Student testStudent = new Student(studentName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentConstructorTestOverLimitID()
        {
            for (var i = 10000; i <= 100001; i++)
            {
                new Student("Pesho Pehsev");
            }
        }
    }
}
