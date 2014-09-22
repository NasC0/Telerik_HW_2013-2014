using System.ComponentModel.DataAnnotations;

namespace Clean.Models
{
    public class GuestResponse
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your phone.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please specify whether you'll attend.")]
        public bool? WillAttend { get; set; }
    }
}