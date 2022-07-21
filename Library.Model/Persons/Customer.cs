using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Customer : Person
    {
        public List<LibraryItem> customerItems;
        public Customer(string Fname,string Lname, int phonenumber) : base(Fname,Lname, phonenumber)
        {
            customerItems = new List<LibraryItem>();

        }

        public override string ToString()
        {
            return $"First name: {FName}. Last name: {LName}. Phone number: {PhoneNumber}";
        }
    }
}
