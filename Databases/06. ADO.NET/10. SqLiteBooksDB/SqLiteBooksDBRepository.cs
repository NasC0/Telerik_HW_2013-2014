using System;
using System.Collections.Generic;
using System.Data.SQLite;
using _09.MySQLBooksDB;

namespace _10.SqLiteBooksDB
{
    public class SqLiteBooksDBRepository : BooksRepository, IBooksDBRepository
    {
        private const string ConnectionString = "Data Source=..\\..\\BooksDB.db; Version=3";
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public SqLiteBooksDBRepository()
        {
            this.dbConnection = new SQLiteConnection(ConnectionString);
        }

        public SqLiteBooksDBRepository(string connectionString)
        {
            this.dbConnection = new SQLiteConnection(connectionString);
        }

        public override ulong AddBook(Book bookToAdd)
        {
            string publishDateString = bookToAdd.PublishDate.ToString(DateTimeFormat);
            string query = string.Format("INSERT INTO Books " +
                                         "(Title, Author, PublishDate, ISBN) " +
                                         "VALUES('{0}', '{1}', '{2}', '{3}')", bookToAdd.Title, bookToAdd.Author, publishDateString, bookToAdd.ISBN);

            SQLiteCommand addBookCommand = new SQLiteCommand(query, (this.dbConnection as SQLiteConnection));

            addBookCommand.ExecuteNonQuery();

            SQLiteCommand getLastID = new SQLiteCommand("SELECT last_insert_rowid()", (this.dbConnection as SQLiteConnection));
            ulong lastID = (ulong)(long)getLastID.ExecuteScalar();

            return lastID;
        }

        protected override List<Book> ExecuteQuery(string query)
        {
            SQLiteCommand fetchBooksCommand = new SQLiteCommand(query, (this.dbConnection as SQLiteConnection));
            var dataReader = fetchBooksCommand.ExecuteReader();

            List<Book> booksList = new List<Book>();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    long bookID = (long)dataReader["ID"];
                    string title = (string)dataReader["Title"];
                    string author = (string)dataReader["Author"];
                    DateTime publishDate = (DateTime)dataReader["PublishDate"];
                    string isbn = (string)dataReader["ISBN"];

                    Book currentBook = new Book()
                    {
                        ID = (int)bookID,
                        Title = title,
                        Author = author,
                        PublishDate = publishDate,
                        ISBN = isbn
                    };

                    booksList.Add(currentBook);
                }
            }

            return booksList;
        }
    }
}
