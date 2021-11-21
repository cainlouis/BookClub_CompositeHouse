using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace BookClub
{
    public class BookClubApplication
    {
        /// <value>
        /// Field
        /// <c> bookList </c>
        /// Serves as the holder to a list of books object
        /// </value>
        List<Book> bookList;

        /// <summary>
        /// Parameterized constructor that get the path to the xml files
        /// </summary>
        /// <param name="filePath"> string representing where to find the xml files </param>
        public BookClubApplication(string filePath)
        {
            bookList = new List<Book>();
            LoadData(filePath);
        }

        /// <summary>
        /// Helper method that populates the bookList
        /// </summary>
        /// <param name="filePath"> string representing where to find the xml files </param>
        private void LoadData(string filePath)
        {
            //load book document
            XElement booksXml = XElement.Load(filePath + "books.xml");
            //Get all descendants
            var bookElements = booksXml.Descendants("book");
            //Create an IEnumerable instance of an anonymous object
            var books = bookElements.Select(book =>
                        new
                        {
                            BookId = book.Attribute("id").Value,
                            Title = book.Element("title").Value,
                            Description = book.Element("description").Value,
                            Genre = book.Element("genre").Value,
                            AuthorLastName = book.Element("author").Attribute("lastName").Value,
                            AuthorFirstName = book.Element("author").Attribute("firstName").Value
                        });

            //Load rating document
            XElement ratingsXml = XElement.Load(filePath + "ratings.xml");
            //Get all descendants
            var ratingElements = ratingsXml.Descendants("book");
            //Create an IEnumerable instance of an anonymous object
            var ratings = ratingElements.Select(rating =>
                        new
                        {
                            BookId = rating.Attribute("id").Value,
                            AvgRating = rating.Elements("rating").Average(e => Double.Parse(e.Value)),
                            NumReaders = rating.Elements("rating").Count()
                        });

            //Join these two collections on the BookID value
            var joined = ratings.Join(books,
                        r => r.BookId,
                        b => b.BookId,
                        (r, b) => new
                        {
                            b.BookId,
                            b.Title,
                            b.Description,
                            b.Genre,
                            b.AuthorLastName,
                            b.AuthorFirstName,
                            r.AvgRating,
                            r.NumReaders
                        });

            //populate the List<Book> field by creating Book objects from the collection of anonymous objects
            foreach (var item in joined)
            {
                Book book = new Book(Int32.Parse(item.BookId), item.Title, item.Description, item.Genre, item.AuthorLastName, item.AuthorFirstName, Math.Round(item.AvgRating, 2), item.NumReaders);
                bookList.Add(book);
            }
        }

        public void Run()
        {

        }
    }
}
