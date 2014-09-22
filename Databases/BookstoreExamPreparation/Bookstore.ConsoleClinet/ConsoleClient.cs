using Bookstore.Data;
using Bookstore.Model;
namespace Bookstore.ConsoleClinet
{
    public class ConsoleClient
    {
        public static void Main()
        {
            var booksData = new BookstoreData();
            var book = new Book()
            {
                Title = "Under the dome",
                Website = "www.underthedome.com",
                ISBN = "9876543211234",
                Price = 9.99m
            };

            var author = new Author()
            {
                Name = "George R. R. Martin",
                Type = AuthorType.Book
            };

            booksData.Books.Add(book);
            book.Authors.Add(author);

            booksData.SaveChanges();
        }
    }
}
