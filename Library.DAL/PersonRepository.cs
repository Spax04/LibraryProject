using System;
using Library.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    /// <summary>
    /// class is recognize a repository for Persons from <see cref="DataMock"/>
    /// </summary>
    public class PersonRepository : IRepository<Person>
    {
       private readonly DataMock _context = DataMock.Instens;
        /// <summary>
        /// Adding Person into <see cref="DataMock.PersonList"/>
        /// </summary>
        public Person Add(Person item)
        {
            _context.PersonList.Add(item);
            return item;
        }

        /// <summary>
        /// Deleting Person into <see cref="DataMock.PersonList"/>
        /// </summary>
        public Person Delete(Guid id)
        {
            var item = _context.PersonList.FirstOrDefault(i => i.Id == id);
            _context.PersonList.Remove(item);
            return item;
        }

        /// <summary>
        /// Getting <see cref="DataMock.PersonList"/> as List
        /// </summary>
        public IQueryable<Person> Get()
        {
            return _context.PersonList.AsQueryable();
        }

        /// <summary>
        /// Getting spicific person by Id
        /// </summary>
        public Person Get(Guid id)
        {
            return _context.PersonList.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Getting employye by his login from <see cref="DataMock.EmployLogins"/>
        /// </summary>
        public Employee GetbyLoginAndPassword(string login)
        {
            if(_context.EmployLogins.ContainsKey(login))
            {
                return _context.EmployLogins[login];
            }
            return null;
        }

        /// <summary>
        /// Seting new employy to <see cref="DataMock.DataMock"/> by his login
        /// </summary>
        public void SetNewLogin(string login,Employee em)
        {
            if(!(_context.EmployLogins.ContainsKey(login)))
            _context.EmployLogins.Add(login, em);
        }

        /// <summary>
        /// updating a person that already exist <see cref="DataMock.PersonList"/>
        /// </summary>
        public Person Update(Person item)
        {
            var old = _context.PersonList.FirstOrDefault(i => i.Id == item.Id);
            if (old != null)
            {
                _context.PersonList.Remove(old);
                _context.PersonList.Add(item);
            }
            return item;
        }
    }
}
