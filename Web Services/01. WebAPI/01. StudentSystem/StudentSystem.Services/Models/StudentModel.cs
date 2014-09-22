using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using StudentSystem.Model;

namespace StudentSystem.Services.Models
{
    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return student => new StudentModel
                {
                    StudentID = student.StudentId,
                    Name = student.Name,
                    FNumber = student.FNumber
                };
            }
        }

        public int StudentID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string FNumber { get; set; }
    }
}