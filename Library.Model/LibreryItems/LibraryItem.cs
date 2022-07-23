using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    /// <summary>
    /// abstract class representing an item handled by the library
    /// </summary>
    public abstract class LibraryItem
    {
        /// <summary>
        /// unique identifier of this item
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// title of name of item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// print or publish date of item
        /// </summary>

        public abstract string Ditales();

        public void sellItem()
        {
            InStock = false;
            outOfStock = DateTime.Now;
        }
        public void outOfStockLI(Customer p1)
        {
            outOfStock = DateTime.Now;
            returnUntil = outOfStock.AddDays(14);
            InStock = false;
            Owner = p1;
        }

        public Customer backInStockLI()
        {
            outOfStock = new DateTime();
            InStock = true;
            return Owner ;
        }

        public bool InStock { get; set; }
        public DateTime outOfStock { get; set; }
        public DateTime returnUntil { get; set; }
        public DateTime PublishDate { get; set; }
        public Customer Owner { get; set; }

        /// <summary>
        /// create a instance of library item
        /// </summary>
        /// <param name="title">the name or title of the new item</param>
        /// <param name="publishDate">the orint or publish date of the new item</param>
        protected LibraryItem(string title, DateTime publishDate)
        {
            Id = Guid.NewGuid();
            Title = title;
            PublishDate = publishDate;
            InStock = true;
        }
        public int CompareTo(object obj)
        {
            LibraryItem li = obj as LibraryItem;
            if (li == null)
            {
                throw new InvalidCastException();
            }
            return this.Title.CompareTo(li.Title);

        }
    }
}