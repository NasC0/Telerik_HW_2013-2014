namespace _09.MySQLBooksDB
{
    public class MySQLBooksDB
    {
        public static void Main()
        {
            var repository = new MySQLBooksDBRepository();
            repository.OpenConnection();

            var booksList = repository.ListBooks();

            foreach (var book in booksList)
            {
                System.Console.WriteLine(book);
            }

            repository.CloseConnection();
        }
    }
}
