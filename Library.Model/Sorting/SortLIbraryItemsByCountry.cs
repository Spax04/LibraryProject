using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class SortLIbraryItemsByCountry : IComparer<LibraryItem>
    {
        public int Compare(LibraryItem li1, LibraryItem li2)
        {
            Book b1 = li1 as Book;
            Book b2 = li2 as Book;
            if (li1 == null || li2 == null)
                throw new InvalidCastException();
            return b1.ISBN.Country.CompareTo(b2.ISBN.Country);
        }
    }
}
