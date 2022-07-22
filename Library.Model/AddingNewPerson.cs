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

        public int convertingPhoneNumber(string number)
        {
            int a;
            try
            {
                 a = Convert.ToInt32(number);
                return a;
            }
            catch
            {
                return 0;
            }
            
           
        }
        
        public string checkingFieldsCustumer()
        {
            StringBuilder sb = new StringBuilder();
            if (_fname == "")
            {
                sb.AppendLine("*No first name has puted");
            }
            if (_lname == "")
            {
                sb.AppendLine("*No last name has puted");
            }
            if (convertingPhoneNumber(_phoneNumber) == 0)
            {
                sb.AppendLine("*Not correct phone number");
            }
           
            return sb.ToString();   
        }
        public string checkingFieldsEmployee()
        {
            StringBuilder sb = new StringBuilder();
            if (_fname == "")
            {
                sb.AppendLine("*No first name has puted");
            }
            if (_lname == "")
            {
                sb.AppendLine("*No last name has puted");
            }
            if (convertingPhoneNumber(_phoneNumber) == 0)
            {
                sb.AppendLine("*Not correct phone number");
            }
            if (_login == "")
            {
                sb.AppendLine("*pleas set login");
            }
            if (_password == "")
            {
                sb.AppendLine("*pleas set password");
            }


            return sb.ToString();
        }

        public Employee registrEmployee()
        {
            Employee e1 = new Employee(_fname,_lname,convertingPhoneNumber(_phoneNumber),_login,_password,_isMananger);
            return e1;
        }
        public Customer registrCustomer()
        {
            Customer e1 = new Customer(_fname, _lname, convertingPhoneNumber(_phoneNumber));
            return e1;
        }
    }
}
