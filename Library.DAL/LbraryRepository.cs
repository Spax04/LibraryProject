using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    /// <summary>
    /// class is recognize a repository for librery items from <see cref="DataMock"/>
    /// </summary>
    public class LbraryRepository : IRepository<LibraryItem>
    {
        private static DataMock _context = DataMock.Instens;
        

        /// <summary>
        /// Adding Libriry Item into <see cref="DataMock.LibraryItemsList"/>
        /// </summary>
        public  LibraryItem Add(LibraryItem item)
        {
            _context.LibraryItemsList.Add(item);
            return item;
        }
       
       

        /// <summary>
        /// Delete Libriry item for <see cref="DataMock.LibraryItemsList"/> by Id
        /// </summary>
        public LibraryItem Delete(Guid id)
        {
            var item = _context.LibraryItemsList.FirstOrDefault(i => i.Id == id);
            if (item != null)
                _context.LibraryItemsList.Remove(item);
            return item;
        }

        /// <summary>
        /// Getting full list of <see cref="DataMock.LibraryItemsList"/>
        /// </summary>
        public IQueryable<LibraryItem> Get()
        {
            return _context.LibraryItemsList.AsQueryable();
        }
       /// <summary>
       /// Geting spicific Libraary Item by his Id from <see cref="DataMock.LibraryItemsList"/>
       /// </summary>
        public LibraryItem Get(Guid id)
        {
            return _context.LibraryItemsList.FirstOrDefault(i => i.Id == id);
        }

        ///<summary>
        /// Method gets LIbrary item that already exist int <see cref="DataMock.LibraryItemsList"/> and updeateing it
        ///</summary>
        public LibraryItem Update(LibraryItem item)
        {
            var old = _context.LibraryItemsList.FirstOrDefault(i => i.Id == item.Id);
            if (old != null)
            {
                _context.LibraryItemsList.Remove(old);
                _context.LibraryItemsList.Add(item);
            }
            return item;
        }

        /// <summary>
        /// Sorting <see cref="DataMock.LibraryItemsList"/> by sotring methot it recives 
        /// </summary>
        /// <param name="comp"> resive object that contains <see cref="IComparer{T}"/></param> interface
        public IQueryable<LibraryItem> GetSortBy(IComparer<LibraryItem> comp)
        {
            _context.LibraryItemsList.Sort(comp);
            return Get();
        }
       


    }
}
