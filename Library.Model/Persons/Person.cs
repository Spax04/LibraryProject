using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public abstract class Person
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public Person(string name,string phonenumber)
        {
            Name = name;
            PhoneNumber = phonenumber;
            Id = Guid.NewGuid();
        }

    }
}
