using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class SortLibraryItemsByName : IComparer<LibraryItem>
    {
        public int Compare(LibraryItem li1, LibraryItem li2)
        {
            if (li1 == null || li2 == null)
                throw new InvalidCastException();
            return li1.Title.CompareTo(li2.Title);
        }
    }
}
