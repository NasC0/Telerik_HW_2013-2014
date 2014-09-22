using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using StudentSystem.Model;

namespace StudentSystem.Services.Models
{
    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return course => new CourseModel()
                {
                    CourseID = course.CourseId,
                    Name = course.Name,
                    Description = course.Description,
                    Materials = course.Materials
                };
            }
        }

        public int CourseID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Materials { get; set; }
    }
}