using System;

namespace BookClub
{
    public class Book
    {
        /// <value>
        /// Property
        /// <c> BookId </c>
        /// Serves as the holder of the unique identifier for each books
        /// </value>
        public int BookId { get; set; }

        /// <value>
        /// Property
        /// <c> Title </c>
        /// Serves as the holder of the title of the book
        /// </value>
        public string Title { get; set; }

        /// <value>
        /// Property
        /// <c> Description </c>
        /// Serves as the holder of the description of the book
        /// </value>
        public string Description { get; set; }

        /// <value>
        /// Property
        /// <c> Genre </c>
        /// Serves as the holder of the genre of the book
        /// </value>
        public string Genre { get; set; }

        /// <value>
        /// Property
        /// <c> AuthorLastName </c>
        /// Serves as the holder of the holder of the book author's last name
        /// </value>
        public string AuthorLastName { get; set; }

        /// <value>
        /// Property
        /// <c> AuthorFirstName </c>
        /// Serves as the holder of the book author's first name
        /// </value>
        public string AuthorFirstName { get; set; }

        /// <value>
        /// Property
        /// <c> Rating </c>
        /// Serves as the holder of the book's rating 
        /// </value>
        public double Rating { get; set; }

        /// <value>
        /// Property
        /// <c> NumReader </c>
        /// Serves as the holder of the book's number of readers
        /// </value>
        public int NumReader { get; set; }

        /// <summary>
        /// Creates a descriptive string for the book object
        /// </summary>
        /// <returns> A descriptive string for the book </returns>
        public override string ToString()
        {
            return $"BookId: {BookId} - Title: {Title} - Description: {Description} - Genre: {Genre} - AuthorLastName: {AuthorLastName} - AuthorFirstName: {AuthorFirstName} - Rating: {Rating} - NumReaders: {NumReader}\n";
        }
    }
}