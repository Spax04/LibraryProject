using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Library.Model
{
    public class AddingNewLibraryItem
    {
        private string _title, _publisher, _serialnumber, _country,_gener,_author,_price;
        private DateTime _datePublisher;
       Jornal.JornalFrequency _frequency;

        private ISBN isbn = new ISBN();
        public AddingNewLibraryItem(string title, DateTime date ,string publisher,string serialnumber,string country,string gener,string author) //Book constractor
        {
            _title = title;
            
            _publisher = publisher;
            _serialnumber = serialnumber;
            _country = country;
            _gener = gener; 
            _author = author;
            _datePublisher = date;
        }

        public AddingNewLibraryItem(string title, DateTime date, string price,Jornal.JornalFrequency jf,string gener,string contributer,string editor,string serialnumber) // Jornal Constractor
        {
            _title=title;
            _price = price;
            _datePublisher=date;
            _frequency = jf;
            _gener=gener;
            _author=contributer;
            _publisher=editor;
            _serialnumber=serialnumber;
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
        public double convertToPrice(string price)
        {
            try
            {
                return Convert.ToInt32(price);
            }
            catch
            {
                return -1;
            }
        }


        public string checkingFieldsBook(string number)
        {
            StringBuilder listIssues = new StringBuilder();

            if(convertToSerialNumber(number) == -1)
            {
                listIssues.AppendLine("*Serial number contains characters.");
            }
            return listIssues.ToString();
        }

        public string checkingFieldsJornal(string number,string price)
        {
            StringBuilder listIssues = new StringBuilder();

            if (convertToSerialNumber(number) == -1)
            {
                listIssues.AppendLine("*Serial number contains characters.");
            }
            if(convertToPrice(price) == -1)
            {
                listIssues.AppendLine("*Wrong price format");
            }

            return listIssues.ToString();
        }

        public static string returnContent(ComboBox Choice)
        {
            string selectedcmb = "";
            var comboBoxItem = Choice.Items[Choice.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                selectedcmb = comboBoxItem.Content.ToString();
            }
            return selectedcmb;
        }

        


        public Book addingBookMethod()
        {
            Book b1 = new Book(_title, _datePublisher, _publisher, convertToSerialNumber(_serialnumber), _country);
            b1.Genres.Add(_gener);
            b1.Authors.Add(_author);
            return b1;
        }

        public Jornal addingJornalMethod()
        {
            Jornal j1 = new Jornal(_title,_datePublisher,convertToPrice(_price),convertToSerialNumber(_serialnumber));
            j1.Ganers = _gener;
            j1.Editors = _publisher;
            j1.Contributers = _author;
            return j1;
        }

      
    }
    
}
