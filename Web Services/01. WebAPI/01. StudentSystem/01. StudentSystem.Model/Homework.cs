using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Model
{
    public class Homework
    {
        public Homework()
        {
            this.TimeSent = DateTime.Now;
        }

        public int HomeworkId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        public DateTime TimeSent { get; set; }

        public int? CourseID { get; set; }

        public virtual Course Course { get; set; }

        public int? StudentID { get; set; }

        public virtual Student Student { get; set; }
    }
}
