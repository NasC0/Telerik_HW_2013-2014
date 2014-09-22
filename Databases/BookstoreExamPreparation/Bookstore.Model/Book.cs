
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bookstore.Model
{
    public class Book
    {
        private ICollection<Author> authors;
        private ICollection<Review> reviews;

        public Book()
        {
            this.authors = new HashSet<Author>();
            this.reviews = new HashSet<Review>();

            this.Price = 0.00m;
        }

        public int BookID { get; set; }

        [Required]
        [MaxLength(200)]
        [Index]
        public string Title { get; set; }

        [StringLength(13)]
        [Index(IsUnique=true)]
        [Index]
        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public string Website { get; set; }

        public virtual ICollection<Author> Authors 
        {
            get
            {
                return this.authors;
            }

            set
            {
                this.authors = value;
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
    }
}
