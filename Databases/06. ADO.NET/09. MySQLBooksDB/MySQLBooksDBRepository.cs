using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace _09.MySQLBooksDB
{
    public class MySQLBooksDBRepository : BooksRepository, IBooksDBRepository
    {
        private const string ConnectionString = "Server=localhost; Port=3306; Database=BooksDB; Uid=root; Pwd=; pooling=true; Convert Zero Datetime=True;";

        private MySqlConnection dbConnection;

        public MySQLBooksDBRepository()
        {
            this.dbConnection = new MySqlConnection(ConnectionString);
        }

        public MySQLBooksDBRepository(string connectionString)
        {
            this.dbConnection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            this.dbConnection.Open();
        }

        public void CloseConnection()
        {
            this.dbConnection.Close();
        }

        public override ulong AddBook(Book bookToAdd)
        {
            MySqlCommand addBookCommand = new MySqlCommand("INSERT INTO Books " +
                                                           "(Title, Author, PublishDate, ISBN) " +
                                                           "VALUES(@title, @author, @publishDate, @isbn)", this.dbConnection);
            addBookCommand.Parameters.AddWithValue("@title", bookToAdd.Title);
            addBookCommand.Parameters.AddWithValue("@author", bookToAdd.Author);
            addBookCommand.Parameters.AddWithValue("@publishDate", bookToAdd.PublishDate);
            addBookCommand.Parameters.AddWithValue("@isbn", bookToAdd.ISBN);

            addBookCommand.ExecuteNonQuery();

            MySqlCommand getLastID = new MySqlCommand("SELECT @@IDENTITY", this.dbConnection);
            ulong lastID = (ulong)getLastID.ExecuteScalar();

            return lastID;
        }

        // TODO: Fix DateTime convertion
        protected override List<Book> ExecuteQuery(string query)
        {
            MySqlCommand listBooksCommand = new MySqlCommand(query, this.dbConnection);
            MySqlDataReader dataReader = listBooksCommand.ExecuteReader();

            var booksList = new List<Book>();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    Book currentBook = new Book
                    {
                        ID = (int)dataReader["ID"],
                        Title = (string)dataReader["Title"],
                        Author = (string)dataReader["Author"],
                        PublishDate = (DateTime)dataReader["PublishDate"],
                        ISBN = (string)dataReader["ISBN"]
                    };

                    booksList.Add(currentBook);
                }
            }

            return booksList;
        }

    }
}