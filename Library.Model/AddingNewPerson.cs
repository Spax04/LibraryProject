using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    /// <summary>
    /// The class is helping to create a new person. Class contains two constructors - one for customer and second for employee
    /// </summary>
    public class AddingNewPerson
    {
        private string _fname, _lname, _phoneNumber, _login, _password;
        private bool _isMananger;
        // For regular customer
        public AddingNewPerson(string fname,string lname,string phonnumber)
        {
            _fname = fname;
            _lname = lname;
            _phoneNumber = phonnumber;

        }
        //For employy
        public AddingNewPerson(string fname, string lname, string phonnumber,string login,string password,bool isMananger)
        {
            _fname = fname;
            _lname = lname;
            _phoneNumber = phonnumber;
            _login = login;
            _password = password;
            _isMananger = isMananger;
        }

        /// <summary>
        /// regular converting methot that checking if phone number is number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
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
        /// <summary>
        /// checking fields of customer page for correct input. return string if input is not correct
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// checking fields of employee page for correct input. return string if input is not correct
        /// </summary>
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

        /// <summary>
        /// method that return new employee
        /// </summary>
        /// <returns></returns>
        public Employee registrEmployee()
        {
            Employee e1 = new Employee(_fname,_lname,convertingPhoneNumber(_phoneNumber),_login,_password,_isMananger);
            return e1;
        }
        /// <summary>
        /// method that returns new customer
        /// </summary>
        public Customer registrCustomer()
        {
            Customer e1 = new Customer(_fname, _lname, convertingPhoneNumber(_phoneNumber));
            return e1;
        }
    }
}
