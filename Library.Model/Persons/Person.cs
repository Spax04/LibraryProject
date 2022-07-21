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
        public string FName { get; private set; }
        public string LName { get; private set; }
        public int PhoneNumber { get; private set; }
        public Person(string Fname, string Lname, int phonenumber)
        {
            FName = Fname;
            LName = Lname;
            PhoneNumber = phonenumber;
            Id = Guid.NewGuid();
        }

    }
}
