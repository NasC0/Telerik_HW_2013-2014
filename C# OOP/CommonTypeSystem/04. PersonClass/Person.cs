/* Task 4. Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. 
 * Override ToString() to display the information of a person and if age is not specified – to say so. 
 * Write a program to test this functionality. */

namespace _04.PersonClass
{
    using System;
    using System.Text;

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Name: {0}\n", this.Name);
            result.Append("Age: ");

            if (this.Age == null)
            {
                result.Append("Not specified");
            }
            else
            {
                result.Append(this.Age);
            }

            return result.ToString();
        }
    }
}
