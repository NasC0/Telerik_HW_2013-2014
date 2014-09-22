using System;
using System.Text;

namespace _09.MySQLBooksDB
{
    public class Book
    {
        public long ID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime PublishDate { get; set; }

        public string ISBN { get; set; }

        public override string ToString()
        {
            StringBuilder bookToString = new StringBuilder();

            bookToString.AppendLine("ID: " + this.ID);
            bookToString.AppendLine("Title: " + this.Title);
            bookToString.AppendLine("Author: " + this.Author);
            bookToString.AppendLine("Publish Date: " + this.PublishDate);
            bookToString.AppendLine("ISBN: " + this.ISBN);

            return bookToString.ToString();
        }
    }
}
