using System.ComponentModel.DataAnnotations;

namespace BugsReporter.Services.Models
{
    public class BugInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Text { get; set; }
    }
}