using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class AddingNewPerson
    {
        private string _fname, _lname, _phoneNumber, _login, _password;
        private bool _isMananger;

        public AddingNewPerson(string fname,string lname,string phonnumber)
        {
            _fname = fname;
            _lname = lname;
            _phoneNumber = phonnumber;

        }
        public AddingNewPerson(string fname, string lname, string phonnumber,string login,string password,bool isMananger)
        {
            _fname = fname;
            _lname = lname;
            _phoneNumber = phonnumber;
            _login = login;
            _password = password;
            _isMananger = isMananger;
        }

        public int convertingPhoneNumber()
        { 
            return Convert.ToInt32(_phoneNumber);
        }

        public Employee registrEmployee()
        {
            Employee e1 = new Employee(_fname,_lname,convertingPhoneNumber(),_login,_password,_isMananger);
            return e1;
        }
        public Customer registrCustomer()
        {
            Customer e1 = new Customer(_fname, _lname, convertingPhoneNumber());
            return e1;
        }
    }
}
