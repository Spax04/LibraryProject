using System;
using Library.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
     class PersonRepository : IRepository<Person>
    {
       private readonly DataMock _context = new DataMock();
        public Person Add(Person item)
        {
            _context.PersonList.Add(item);
            return item;
        }

        public Person Delete(Guid id)
        {
            var item = _context.PersonList.FirstOrDefault(i => i.Id == id);
            _context.PersonList.Remove(item);
            return item;
        }

        public IQueryable<Person> Get()
        {
            throw new NotImplementedException();
        }

        public Person Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
