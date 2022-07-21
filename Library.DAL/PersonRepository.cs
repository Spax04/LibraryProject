using System;
using Library.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
     public class PersonRepository : IRepository<Person>
    {
       private readonly DataMock _context = DataMock.Instens;
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
            return _context.PersonList.AsQueryable();
        }

        public Person Get(Guid id)
        {
            return _context.PersonList.FirstOrDefault(i => i.Id == id);
        }
        public Employee GetbyLoginAndPassword(string login)
        {
            if(_context.EmployLogins.ContainsKey(login))
            {
                return _context.EmployLogins[login];
            }
            return null;
        }

        public Person Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
