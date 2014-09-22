using System.Collections.Generic;

namespace _09.MySQLBooksDB
{
    public interface IBooksDBRepository
    {
        void OpenConnection();

        void CloseConnection();

        ulong AddBook(Book bookToAdd);

        List<Book> ListBooks();

        List<Book> FindBookByName(string bookName);
    }
}
