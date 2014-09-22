/* Task 9. Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. */

namespace Student.Common
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public Student(string firstName, string lastName, string fNumber, string tNumber, string email, int grpNumber, Group grp)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = fNumber;
            this.TelephoneNumber = tNumber;
            this.EmailAddress = email;
            this.Groupnumber = grpNumber;
            this.Marks = new List<int>();
            this.Group = grp;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FacultyNumber { get; set; }

        public string TelephoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public int Groupnumber { get; set; }

        public List<int> Marks { get; set; }

        public Group Group { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}, F: {2}, T: {3}, E: {4}, G: {5}", this.FirstName, this.LastName, this.FacultyNumber, this.TelephoneNumber, this.EmailAddress, this.Groupnumber);
        }
    }
}
