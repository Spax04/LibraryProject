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
        private string _title, _publisher, _serialnumber, _country,_gener,_author;
        private DateTime _datePublisher;
        private ISBN isbn = new ISBN();
        public AddingNewLibraryItem(string title,/*string date,*/ DateTime date ,string publisher,string serialnumber,string country,string gener,string author)
        {
            _title = title;
            
            _publisher = publisher;
            _serialnumber = serialnumber;
            _country = country;
            _gener = gener; 
            _author = author;
            _datePublisher = date;
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

        public string checkingFields(string number)
        {
            StringBuilder listIssues = new StringBuilder();

            if(convertToSerialNumber(number) == -1)
            {
                listIssues.AppendLine("*Serial number contains characters.");
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
            Book b1 = new Book(_title, /*convertingToDate(_date),*/_datePublisher, _publisher, convertToSerialNumber(_serialnumber), _country);
            b1.Genres.Add(_gener);
            b1.Authors.Add(_author);
            return b1;
        }

      
    }
    
}
