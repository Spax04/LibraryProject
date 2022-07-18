using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class AddingNewBookClass
    {
        private string _title, _date, _publisher, _serialnumber, _country;
        private ISBN isbn = new ISBN();
        public AddingNewBookClass(string title,string date,string publisher,string serialnumber,string country)
        {
            _title = title;
            _date = date;
            _publisher = publisher;
            _serialnumber = serialnumber;
            _country = country;

        }

        public DateTime convertingToDate(string date)
        {
            try
            {
                DateTime temp = Convert.ToDateTime(date);
                return temp;
            }
            catch 
            {
                return DateTime.MinValue;
            }
        }

        public bool publisherExist(string publisher)
        {
            if (ISBN.Publishers.ContainsKey(publisher))
            {
                return true;
            }
            return false;
        }

        public bool countryExist(string country)
        {
            if (ISBN.Countries.ContainsKey(country))
            {
                return true;
            }
            return false;
        }

        public int convertToSerialNumber(string _serialnumber)
        {
            try
            {
                return Convert.ToInt32(_serialnumber);
            }catch 
            {
                return -1;
                
            }
        }

        public string checkingFields(string date,string number)
        {
            StringBuilder listIssues = new StringBuilder();
            if (convertingToDate(date) == DateTime.MinValue) //&& publisherExist(_publisher) && countryExist(_country)
            {
                listIssues.AppendLine("*Wrong date format. Date exemple: 1999,12,31");
            }
            if (!(publisherExist(_publisher)))
            {
                listIssues.AppendLine("*There is no publisher like this. Check agean publisher name");
            }
            if (!(countryExist(_country)))
            {
                listIssues.AppendLine("*Wrong country. Check agean country name.");
            }
            if(convertToSerialNumber(number) == -1)
            {
                listIssues.AppendLine("*Serial number contains characters.");
            }
            return listIssues.ToString();
        }

        public Book addingBookMethod()
        {
            Book b1 = new Book(_title, convertingToDate(_date), _publisher, convertToSerialNumber(_serialnumber), _country);
            return b1;
        }

      
    }
    public class NewBookInputException : Exception
    {
        public NewBookInputException(string message)
            : base(message) { }
    }
}
