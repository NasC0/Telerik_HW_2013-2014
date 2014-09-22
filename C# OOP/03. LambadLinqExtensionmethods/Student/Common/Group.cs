/* Task 16. Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. */

namespace Student.Common
{
    using System;
    
    public class Group
    {
        public Group(int grpNumber, string depName)
        {
            this.GroupNumber = grpNumber;
            this.DepartmentName = depName;
        }

        public int GroupNumber { get; set; }

        public string DepartmentName { get; set; }

        public override string ToString()
        {
            return string.Format("Group Number: {0}; Department Name: {1}", this.GroupNumber, this.DepartmentName); 
        }
    }
}
