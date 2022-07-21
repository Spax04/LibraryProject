using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    /// <summary>
    /// class representing book handled by the library
    /// </summary>
    public class Book : LibraryItem , IComparable
    {
        private const string _defaultState = "Israel";
        private const string _defaultPublisher = "Pyramid Books";

        /// <summary>
        /// list of known genres for books
        /// </summary>
        public static List<string> BookGenres = new List<string>();

        /// <summary>
        /// list of known authers
        /// </summary>
        public static List<string> KnownAuthors = new List<string>();

        /// <summary>
        ///  get international standard book number <see cref="Library.Model.ISBN"/>
        /// </summary>
        public ISBN ISBN { get; private set; }

        /// <summary>
        /// get collection of book's authors
        /// </summary>
        public List<string> Authors { get; private set; }

        /// <summary>
        /// Get or set book's publisher. Must be a known publisher by the <see cref="Library.Model.ISBN"/>
        /// </summary>
        /// <exception cref="IsbnException">thrown when attempting to set publisher value that is not recognized by ISBN</exception>
        public string Publisher
        {
            get
            {
                return this.ISBN.Publisher;
            }
        }

        /// <summary>
        /// get collection of book's genres
        /// </summary>
        public List<string> Genres { get; private set; }

        /// <summary>
        /// get or set book's revision
        /// </summary>
        public int Revision { get; set; }

       
        
        public StringBuilder authorsPrint()
        {
            StringBuilder authors = new StringBuilder();
            for(int i = 0; i < Authors.Count; i++)
            {
                authors.Append($"{Authors[i]} ");
            }
            return authors;
        }
        public StringBuilder genersPrint()
        {
            StringBuilder geners = new StringBuilder();
            for (int i = 0; i < Genres.Count; i++)
            {
                geners.Append($"{Genres[i]} ");
            }
            return geners;

        }
        /// <summary>
        /// get or set book's synopsis (short summary of book)
        /// </summary>
        public string Synopsis { get; set; }
       
       
        /// <summary>
        /// create an instance of book
        /// </summary>
        /// <param name="title">the title of the new book</param>
        /// <param name="publishDate">the date the new book was published</param>
        /// <param name="serialNumber">optional parameter, the book's serial number for the <see cref="Model.ISBN"/>. 
        /// Every title from the same publisher should have a unique serial number</param>
        /// <param name="country">optional parameter, the state form the <see cref="Model.ISBN"/>.
        /// Default value is "Israel"</param>
        public Book(string title, DateTime publishDate, string publisher = _defaultPublisher, int serialNumber = 0,
            string country = _defaultState) : base(title, publishDate)
        {
            this.ISBN = new ISBN() { SerialNumber = serialNumber };
            this.ISBN.Country = country;
            this.ISBN.Publisher = publisher;
            Authors = new List<string>();
            Genres = new List<string>();
            
        }

        public override string ToString()
        {
            return $"'{Title}' | {PublishDate:yyyy} | {ISBN.ToString()} | {authorsPrint()}| {genersPrint()} | {this.ISBN.Country} | {this.ISBN.Publisher}";
        }

        
    }
}
