﻿using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class LbraryRepository : IRepository<LibraryItem>
    {
        private static DataMock _context = DataMock.Instens;
        

        //Adding Items
        public  LibraryItem Add(LibraryItem item)
        {
            _context.LibraryItemsList.Add(item);
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
        
        //Get elemets
        public IQueryable<LibraryItem> Get()
        {
            return _context.LibraryItemsList.AsQueryable();
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
       


    }
}
