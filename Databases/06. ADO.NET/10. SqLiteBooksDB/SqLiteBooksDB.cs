
using System;
using _09.MySQLBooksDB;
namespace _10.SqLiteBooksDB
{
    public class SqLiteBooksDB
    {
        public static void Main()
        {
            var repository = new SqLiteBooksDBRepository();
            repository.OpenConnection();

            Book bookToAdd = new Book()
            {
                Title = "Tomyknockers",
                Author = "Stephen King",
                PublishDate = DateTime.Now,
                ISBN = "654654984645"
            };

            repository.AddBook(bookToAdd);

            var booksList = repository.ListBooks();

            foreach (var book in booksList)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("--------------------------------------");

            var filteredBooksList = repository.FindBookByName("tomy");

            foreach (var book in filteredBooksList)
            {
                Console.WriteLine(book);
            }

            repository.CloseConnection();
        }
    }
}
