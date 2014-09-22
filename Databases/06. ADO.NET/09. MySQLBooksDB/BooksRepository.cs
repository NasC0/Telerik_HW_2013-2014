using System.Collections.Generic;
using System.Data;

namespace _09.MySQLBooksDB
{
    public abstract class BooksRepository : IBooksDBRepository
    {
        protected IDbConnection dbConnection;

        public void OpenConnection()
        {
            this.dbConnection.Open();
        }

        public void CloseConnection()
        {
            this.dbConnection.Close();
        }

        public abstract ulong AddBook(Book bookToAdd);

        public virtual List<Book> ListBooks()
        {
            string listBooksQuery = "SELECT * FROM Books";
            return this.ExecuteQuery(listBooksQuery);
        }

        public virtual List<Book> FindBookByName(string bookName)
        {
            bookName = this.ConvertToSearchString(bookName);
            string findBookQuery = "SELECT * FROM Books " +
                                   "WHERE Title LIKE '" + bookName + "'";

            return this.ExecuteQuery(findBookQuery);
        }

        protected string ConvertToSearchString(string searchCriteria)
        {
            return '%' + searchCriteria + '%';
        }

        protected abstract List<Book> ExecuteQuery(string query);
    }
}
