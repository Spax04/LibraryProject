using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class SortLibraryItemsByYear : IComparer<LibraryItem>
    {
        public int Compare(LibraryItem li1, LibraryItem li2)
        {
            if (li1 == null || li2 == null)
                throw new InvalidCastException();
            return li1.PublishDate.CompareTo(li2.PublishDate);
        }
    }
}
