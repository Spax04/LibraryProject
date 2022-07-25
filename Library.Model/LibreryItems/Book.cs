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
        private const string _defaultState = "Russian";
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
        public string Genres { get; set; }

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
            
            
        }

        public override string ToString()
        {
            if(InStock == true)
            {
                return $"'{Title}' | {PublishDate:yyyy} | {ISBN.ToString()} | {authorsPrint()}| {Genres} | {this.ISBN.Country} | {this.ISBN.Publisher}";
            }
            else
            {
                return $" OUT OF STOCK | '{Title}' | {PublishDate:yyyy} | {ISBN.ToString()} | {authorsPrint()}| {Genres} | {this.ISBN.Country} | {this.ISBN.Publisher}";

            }
        }

        /// <summary>
        /// represents ditales about book
        /// </summary>
        public override string Ditales()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Book information");
            sb.AppendLine($"Book title: {Title}");
            sb.AppendLine($"Publish year: {PublishDate:yyyy}");
            sb.AppendLine($"Publisher: {this.ISBN.Publisher}");
            sb.AppendLine($"Book Gener: {Genres}");
            sb.AppendLine($"Author: {authorsPrint()}");
            sb.AppendLine($"Country: {this.ISBN.Country}");
            sb.AppendLine($"ISBN: {ISBN.ToString()}");
            sb.AppendLine($"Synopsis: \n {Synopsis}");
            if(InStock == true)
            {
                sb.AppendLine($"Book is in stock");
            }
            else
            {
                sb.AppendLine($"Book is out of stock.\nDate:{outOfStock:d}");
                sb.AppendLine($"Return until: {returnUntil:d}");
                if(returnUntil < DateTime.Now)
                {
                    sb.AppendLine("OVERDUE!!!"); 
                }
            }
            return sb.ToString();
        }
    
    }
}
