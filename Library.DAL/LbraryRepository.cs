using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class LbraryRepository : IRepository<LibraryItem>
    {
        private static  DataMock _context = new DataMock();

        //Adding Items
        public  LibraryItem Add(LibraryItem item)
        {
            _context.LibraryItemsList.Add(item);
            return item;
        }
        public LibraryItem AddBook(Book item)
        {
            _context.BookItemsList.Add(item);
            return item;
        }
        public LibraryItem AddJornal(Jornal item)
        {
            _context.JornalItemsList.Add(item);
            return item;
        }

        //Deleting items
        public LibraryItem Delete(Guid id)
        {
            var item = _context.LibraryItemsList.FirstOrDefault(i => i.Id == id);
            if (item != null)
                _context.LibraryItemsList.Remove(item);
            return item;
        }
        public Book DeleteBook(Guid id)
        {
            var item = _context.BookItemsList.FirstOrDefault(i => i.Id == id);
            if (item != null)
                _context.BookItemsList.Remove(item);
            return item;
        }
        public Jornal DeleteJornal(Guid id)
        {
            var item = _context.JornalItemsList.FirstOrDefault(i => i.Id == id);
            if (item != null)
                _context.JornalItemsList.Remove(item);
            return item;
        }
        //Get elemets
        public IQueryable<LibraryItem> Get()
        {
            return _context.LibraryItemsList.AsQueryable();
        }
        public IQueryable<Book> GetBook()
        {
            return _context.BookItemsList.AsQueryable();
        }
        public IQueryable<Jornal> GetJornal()
        {
            return _context.JornalItemsList.AsQueryable();
        }


        public LibraryItem Get(Guid id)
        {
            return _context.LibraryItemsList.FirstOrDefault(i => i.Id == id);
        }

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

        public IQueryable<LibraryItem> GetSortBy(IComparer<LibraryItem> comp)
        {
            _context.LibraryItemsList.Sort(comp);
            return Get();
        }
        public IQueryable<Book> GetSortBookBy(IComparer<Book> comp)
        {
            _context.BookItemsList.Sort(comp);
            return GetBook();
        }
        public IQueryable<Jornal> GetSortJornalBy(IComparer<Jornal> comp)
        {
            _context.JornalItemsList.Sort(comp);
            return GetJornal();
        }


    }
}
