using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Xml.Linq;
using BookStore.Data;
using BookStore.Model;

namespace BookStore.ImportFromXml
{
    public class ImportFromXml
    {
        private const string FileLocation = "../../complex-books.xml";

        public static void ImportBooks(XDocument booksXml, IBookStoreData dbContext)
        {
            var booksList = booksXml.Descendants("book");

            foreach (var book in booksList)
            {
                using (var transaction = dbContext.BeginTransaction())
                {
                    try
                    {
                        var bookToAdd = ProcessBook(book, dbContext);
                        var authors = ProcessAuthors(book, dbContext);
                        var reviews = ProcessReviews(book, dbContext, bookToAdd);

                        foreach (var author in authors)
                        {
                            bookToAdd.Authors.Add(author);
                            author.Books.Add(bookToAdd);
                        }

                        foreach (var review in reviews)
                        {
                            bookToAdd.Reviews.Add(review);
                        }

                        dbContext.Books.Add(bookToAdd);
                        dbContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (ArgumentNullException ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    catch (ArgumentException ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    catch (DbUpdateException ex)
                    {
                        throw new ArgumentException("Cannot insert dublicate ISBN number.");
                    }
                }
            }
        }

        private static Book ProcessBook(XElement bookNode, IBookStoreData dbContext)
        {
            var bookTitle = bookNode.Descendants("title").FirstOrDefault().Value;

            string bookWebSite = null;
            if (bookNode.Descendants("web-site").FirstOrDefault() != null)
            {
                bookWebSite = bookNode.Descendants("web-site").FirstOrDefault().Value;
            }

            string isbn = null;
            if (bookNode.Descendants("isbn").FirstOrDefault() != null)
            {
                isbn = bookNode.Descendants("isbn").FirstOrDefault().Value;
            }

            decimal price = 0;
            if (bookNode.Descendants("price").FirstOrDefault() != null)
            {
                price = decimal.Parse(bookNode.Descendants("price").FirstOrDefault().Value);
            }

            var resultBook = new Book()
            {
                Title = bookTitle
            };

            if (bookWebSite != null)
            {
                resultBook.Website = bookWebSite;
            }

            if (isbn != null)
            {
                if (dbContext.Books.Find(x => x.ISBN == isbn).Count() > 0)
                {
                    throw new ArgumentException("ISBN Value must be unique.");
                }
                resultBook.ISBN = isbn;
            }

            resultBook.Price = price;

            return resultBook;
        }

        private static ICollection<Author> ProcessAuthors(XElement bookNode, IBookStoreData dbContext)
        {
            var authorsCollection = bookNode.Elements("authors").Select(author => author.Value);
            List<Author> authorsList = new List<Author>();

            if (authorsCollection.Count() <= 0)
            {
                return authorsList;
            }
            else
            {
                foreach (var author in authorsCollection)
                {
                    var currentAuthor = dbContext.Authors.Find(x => x.Name == author).FirstOrDefault();
                    if (currentAuthor == null)
                    {
                        currentAuthor = new Author()
                        {
                            Name = author,
                            AuthorType = AuthorType.Book
                        };

                        dbContext.Authors.Add(currentAuthor);
                    }
                    else if (currentAuthor != null && currentAuthor.AuthorType == AuthorType.Review)
                    {
                        currentAuthor.AuthorType = AuthorType.Both;
                    }

                    authorsList.Add(currentAuthor);
                }
            }

            return authorsList;
        }

        private static ICollection<Review> ProcessReviews(XElement bookNode, IBookStoreData dbContext, Book reviewBook)
        {
            var reviewsCollection = bookNode.Descendants("reviews").Nodes();
            List<Review> reviewsList = new List<Review>();

            if (reviewsCollection.Count() <= 0)
            {
                return reviewsList;
            }
            else
            {
                foreach (XElement review in reviewsCollection)
                {
                    var reviewDateString = review.Attribute("date") == null ? null : review.Attribute("date").Value;
                    DateTime reviewDate;
                    if (!DateTime.TryParse(reviewDateString, out reviewDate))
                    {
                        reviewDate = DateTime.Now.Date;
                    }

                    var author = review.Attribute("author") == null ? null : review.Attribute("author").Value;
                    Author reviewAuthor = null;
                    if (author != null)
                    {
                        reviewAuthor = dbContext.Authors.Find(x => x.Name == author).FirstOrDefault();
                        if (reviewAuthor == null)
                        {
                            reviewAuthor = new Author()
                            {
                                Name = author,
                                AuthorType = AuthorType.Review
                            };

                            dbContext.Authors.Add(reviewAuthor);
                        }
                        else if (reviewAuthor != null && reviewAuthor.AuthorType == AuthorType.Book)
                        {
                            reviewAuthor.AuthorType = AuthorType.Both;
                        }
                    }

                    var reviewText = review.Value;
                    if (string.IsNullOrWhiteSpace(reviewText))
                    {
                        throw new ArgumentException("Review must have text.");
                    }

                    Review currentReview = new Review()
                    {
                        ReviewText = reviewText,
                        Book = reviewBook,
                        DateOfCreation = reviewDate
                    };

                    if (reviewAuthor != null)
                    {
                        currentReview.Author = reviewAuthor;
                    }

                    dbContext.Reviews.Add(currentReview);
                    reviewsList.Add(currentReview);
                }
            }

            return reviewsList;
        }

        public static void Main()
        {
            var booksXml = XDocument.Load(FileLocation);
            IBookStoreData dbContext = new BookStoreData();
            ImportBooks(booksXml, dbContext);
        }
    }
}
