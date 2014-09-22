/* Task 1. Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, mobile phone e-mail, course, 
 * specialty, university, faculty. Use an enumeration for the specialties, universities and faculties. 
 * Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=. */

namespace StudentClasses
{
    using System;
    using System.Text;

    public class Student : ICloneable, IComparable<Student>
    {
        public Student(string fullName, int socialSecurityNumber, int course, University uni, Faculty faculty, Specialty specialty)
        {
            string[] fullNameSplit = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                this.FirstName = fullNameSplit[0];
                this.MiddleName = fullNameSplit[1];
                this.LastName = fullNameSplit[2];
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("Invalid name passed! You must pass all three names of the student.");
            }

            this.SocialSecurityNumber = socialSecurityNumber;
            this.Course = course;
            this.University = uni;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public long SocialSecurityNumber { get; private set; }

        public string Address { get; set; }

        public string MobilePhone { get; set; }

        public string EMail { get; set; }

        public int Course { get; private set; }

        public University University { get; private set; }

        public Faculty Faculty { get; private set; }

        public Specialty Specialty { get; private set; }

        public override bool Equals(object obj)
        {
            Student otherStudent = obj as Student;
            if (otherStudent == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, otherStudent))
            {
                return true;
            }

            return (this.Course == otherStudent.Course) && (this.University == otherStudent.University) && (this.Faculty == otherStudent.Faculty) && (this.Specialty == otherStudent.Specialty);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.SocialSecurityNumber.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Name: {0} {1} {2}\n", this.FirstName, this.MiddleName, this.LastName);
            result.AppendFormat("SSN: {0}\n", this.SocialSecurityNumber);
            result.AppendFormat("Address: {0}\n", this.Address);
            result.AppendFormat("Phone number: {0}\n", this.MobilePhone);
            result.AppendFormat("Email: {0}\n", this.EMail);
            result.AppendFormat("Course: {0}\n", this.Course);
            result.AppendFormat("University: {0}\n", this.University.ToString());
            result.AppendFormat("Faculty: {0}\n", this.Faculty.ToString());
            result.AppendFormat("Specialty: {0}", this.Specialty);

            return result.ToString();
        }

        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !Student.Equals(first, second);
        }

        /* Task 2. Add implementations of the ICloneable interface. 
         * The Clone() method should deeply copy all object's fields into a new object of type Student.
         * Since we don't have any reference types as properties, i chose to use MemberwiseClone */
 
        public object Clone()
        {
            Student newStudent = this.MemberwiseClone() as Student;

            return newStudent;
        }

        /* Task 3. Implement the  IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) 
         * and by social security number (as second criteria, in increasing order). */

        public int CompareTo(Student other)
        {
            if (this.LastName != other.LastName)
            {
                return this.LastName.CompareTo(other.LastName);
            }
            else if (this.FirstName != other.FirstName)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
            else if (this.MiddleName != other.MiddleName)
            {
                return this.MiddleName.CompareTo(other.MiddleName);
            }

            return this.SocialSecurityNumber.CompareTo(other.SocialSecurityNumber);
        }
    }
}
