using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using StudentSystem.Model;

namespace StudentSystem.Services.Models
{
    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return hw => new HomeworkModel
                {
                    HomeworkID = hw.HomeworkId,
                    Content = hw.Content,
                    TimeSent = hw.TimeSent,
                    CourseID = hw.CourseID,
                    StudentID = hw.StudentID
                };
            }
        }

        public int HomeworkID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        public DateTime TimeSent { get; set; }

        public int? CourseID { get; set; }

        public int? StudentID { get; set; }
    }
}