using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Model
{
    public class Author
    {
        private ICollection<Book> books;
        private ICollection<Review> reviews;
        
        public Author()
        {
            this.books = new HashSet<Book>();
            this.reviews = new HashSet<Review>();
        }

        [Key]
        public int AuthorID { get; set; }

        [MaxLength(50)]
        [Required]
        [Index(IsUnique=true)]
        public string Name { get; set; }

        [Required]
        public AuthorType AuthorType { get; set; }

        public virtual ICollection<Book> Books
        {
            get
            {
                return this.books;
            }

            set
            {
                this.books = value;   
            }
        }

        public virtual ICollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
