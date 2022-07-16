﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    /// <summary>
    /// class representing book handled by the library
    /// </summary>
    public class Book : LibraryItem
    {
        private const string _defaultState = "Israel";
        

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
            set
            {
                this.ISBN.Publisher = value; 
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
        /// <param name="languige">optional parameter, the languige for the <see cref="Model.ISBN"/>. 
        /// Default value is "Hebrew"</param>
        /// <param name="state">optional parameter, the state form the <see cref="Model.ISBN"/>.
        /// Default value is "Israel"</param>
        public Book(string title, DateTime publishDate, int serialNumber = 0,
            string country = _defaultState) : base(title, publishDate)
        {
            this.ISBN = new ISBN() { SerialNumber = serialNumber };
            this.ISBN.Country = country ;
            Authors = new List<string>();
            Genres = new List<string>();
        }

        
    }
}
