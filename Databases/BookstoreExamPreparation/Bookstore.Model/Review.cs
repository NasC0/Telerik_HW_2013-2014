using System;
using System.ComponentModel.DataAnnotations;
namespace Bookstore.Model
{
    public class Review
    {
        public int ReviewID { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }

        [Required]
        public string ReviewText { get; set; }

        public int AuthorID { get; set; }

        public virtual Author Author { get; set; }

        public int BookID { get; set; }

        public virtual Book Book { get; set; }
    }
}
