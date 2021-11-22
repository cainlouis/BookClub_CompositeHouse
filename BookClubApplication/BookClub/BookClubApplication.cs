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

            // foreach (Book book in bookList)
            // {
            //     Console.WriteLine(book.ToString());
            // }
        }

        public void Run()
        {
            int choice;
            Console.WriteLine("Welcome to the Book Appreciation Club!");
            do
            {
                choice = Int32.Parse(Menu());
                switch (choice)
                {
                    case 1:
                        printTopRatedBooks();
                        break;
                    case 2:
                        printByGenre();
                        break;
                    case 3:
                        printByKeyword();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("The number entered is not part of the options. Please choose between 1 and 5 inclusively.");
                        break;
                }
            } while (choice != 5);
            Console.WriteLine("You have chosen to quit the application, have a nice day!");
        }

        /// <summary>
        /// This method print the menu and 
        /// </summary>
        /// <returns> A string that represents the user choice </returns>
        private string Menu()
        {
            Console.WriteLine("Enter the number of your option of choice!");
            Console.WriteLine("1. View the 5 top-rated books.");
            Console.WriteLine("2. Browse books by popular genre.");
            Console.WriteLine("3. Search for a book by keywords.");
            Console.WriteLine("4. Surprise Me!");
            Console.WriteLine("5. Quit.");
            string choice = Console.ReadLine();
            return choice;
        }

        /// <summary>
        /// This method Print the 5 most rated book with the highest number of readers
        /// </summary>
        private void printTopRatedBooks()
        {
            var mostReadBook = bookList.OrderByDescending(b => b.NumReader).Select(b => new { b.Title, b.Rating, b.NumReader }).Take(10);
            var topBooks = mostReadBook.OrderByDescending(b => b.Rating).Select(b => b.Title).Take(5);
            Console.WriteLine("**************************************");
            Console.WriteLine("*********  Top Rated books  **********");
            int count = 1;
            foreach (var b in topBooks)
            {
                Console.WriteLine("**************************************");
                Console.WriteLine(count + ". " + b);
                count++;
            }
            Console.WriteLine("**************************************");
        }

        private void printByGenre()
        {
            var bookByGenre = from book in bookList
                              group book by book.Genre into bookGenre
                              orderby bookGenre.Sum(b => b.NumReader) descending, bookGenre.Average(b => b.Rating) descending
                              select bookGenre;

            Console.WriteLine("*************************************************");
            Console.WriteLine("***************  Books by Genre  ****************");
            foreach (var genre in bookByGenre)
            {
                Console.WriteLine("*************************************************");
                Console.WriteLine("Book Genre: " + genre.Key);
                int count = 1;
                foreach (var book in genre)
                {
                    Console.WriteLine($"Book {count}: {book.Title}");
                    count++;
                }
                Console.WriteLine($"Number of books: {genre.ToList().Count}");
                Console.WriteLine($"Average Rating: {Math.Round(genre.Average(e => e.Rating), 2)}");
                Console.WriteLine("*************************************************");
            }
        }

        private void printByKeyword()
        {
            Console.WriteLine("*******************************************");
            Console.Write("Enter a keyword : ");
            string keyword = Console.ReadLine().ToLower();
            Console.WriteLine("*******************************************");

            var keywordRelated = bookList.Where(b => b.Title.ToLower().Contains(keyword) || b.Description.ToLower().Contains(keyword)).Select(b => b.Title);
            Console.WriteLine("*********  Keyword related book  **********");
            int count = 1;
            foreach (var book in keywordRelated)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine($"{count}. {book}");
                count++;
            }
            Console.WriteLine("*******************************************");
        }
    }
}
