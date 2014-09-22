using System.ComponentModel.DataAnnotations;

using BugsReporter.Models;

namespace BugsReporter.Services.Models
{
    public class BugStatusChangeModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(15)]
        public string Status { get; set; }
    }
}