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
        public Customer(string name, string phonenumber) : base(name, phonenumber)
        {
            customerItems = new List<LibraryItem>();

        }
    }
}
