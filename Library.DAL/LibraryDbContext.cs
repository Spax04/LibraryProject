using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL;
using Library.Model;

namespace Library.DAL
{
    public class LibraryDbContext
    {
        private LibraryDbContext _instens;
        public LibraryDbContext Instens // Silginton
        {
            get {
                if(null == _instens)
                {
                    _instens = new LibraryDbContext();
                }
                return _instens; 
            }
        }

        
    }
}
