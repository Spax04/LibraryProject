using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class SortJornalByPrice : IComparer<LibraryItem>
    {
        public int Compare(LibraryItem li1, LibraryItem li2)
        {
            Jornal b1 = li1 as Jornal;
            Jornal b2 = li2 as Jornal;
            if (b1 == null || b2 == null)
                return -1;
            return b1.Price.CompareTo(b2.Price);
        }
    }
    
}
