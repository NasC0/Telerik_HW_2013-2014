using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Model
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }

        [Required]
        public string ReviewText { get; set; }

        public int? AuthorID { get; set; }

        public virtual Author Author { get; set; }

        [Required]
        public virtual Book Book { get; set; }

        public int BookID { get; set; }
    }
}
