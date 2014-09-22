namespace TelerikAcademy.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            Employees1 = new HashSet<Employee>();
            WorkHours = new HashSet<WorkHour>();
            Projects = new HashSet<Project>();
        }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }

        public int DepartmentID { get; set; }

        public int? ManagerID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime HireDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        public int? AddressID { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Employee> Employees1 { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual ICollection<WorkHour> WorkHours { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
