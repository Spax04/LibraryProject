using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Library.Model
{
    /// <summary>
    /// The class is helping to create a new libriray item. Class contains two constructors - one for book and second for jornal
    /// </summary>
    public class AddingNewLibraryItem
    {
        private string _title, _publisher, _serialnumber, _country,_gener,_author,_price , _synopsis,_discount;
        private DateTime _datePublisher;
       Jornal.JornalFrequency _frequency;

        private ISBN isbn = new ISBN();
        public AddingNewLibraryItem(string title, DateTime date ,string publisher,string serialnumber,string country,string gener,string author, string synopsis) //Book constractor
        {
            _title = title;
            _publisher = publisher;
            _serialnumber = serialnumber;
            _country = country;
            _gener = gener; 
            _author = author;
            _datePublisher = date;
            _synopsis = synopsis;
        }

        public AddingNewLibraryItem(string title, DateTime date, string price,Jornal.JornalFrequency jf,string gener,string contributer,string editor,string serialnumber,string discount) // Jornal Constractor
        {
            _title=title;
            _price = price;
            _datePublisher=date;
            _frequency = jf;
            _gener=gener;
            _author=contributer;
            _publisher=editor;
            _serialnumber=serialnumber;
            _discount = discount;
        }

        /// <summary>
        /// regular converting to Int32. Return -1 if serial number was wrong
        /// </summary>
        /// <param name="_serialnumber"> resive word that has to be posable to convert </param>
        /// <returns></returns>
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
        /// <summary>
        /// regular converting to Double. Return -1 if price was not correct 
        /// </summary>
        /// <param name="_serialnumber"> resive word that has to be posable to convert </param>
        /// <returns></returns>
        public double convertToPrice(string price)
        {
            try
            {
                return Convert.ToDouble(price);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// checking if all inputs in Fields are correct.If something is not correct it will return isses string else it returns string empty/>
        /// </summary>
        /// <param name="number"> serial number</param>
        /// <returns></returns>
        public string CheckingFieldsBook(string number)
        {
            StringBuilder listIssues = new StringBuilder();
            if (_title == "")
            {
                listIssues.AppendLine("*You forote to set a tittle.");
            }
            if (_author == "")
            {
                listIssues.AppendLine("*You forote to set an Author.");
            }
            if (_title == "")
            {
                listIssues.AppendLine("*You forote to set a tittle.");
            }
            if (convertToSerialNumber(number) == -1)
            {
                listIssues.AppendLine("*Serial number contains characters.");
            }
            return listIssues.ToString();
        }

        public string CheckingFieldsJornal(string number,string price)
        {
            StringBuilder listIssues = new StringBuilder();
            if (_title == "")
            {
                listIssues.AppendLine("*You forote to set a tittle.");
            }
            if(_publisher == "")
            {
                listIssues.AppendLine("*You forote to set a Editor.");
            }
            if (_author == "")
            {
                listIssues.AppendLine("*You forote to set a Contributer.");
            }
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

        /// <summary>
        /// Returning string content fromm ComboboxItem
        /// </summary>
        /// <param name="Choice"> any Combobox</param>
        /// <returns></returns>
        public static string ReturnContent(ComboBox Choice)
        {
            string selectedcmb = "";
            var comboBoxItem = Choice.Items[Choice.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                selectedcmb = comboBoxItem.Content.ToString();
            }
            return selectedcmb;
        }

        /// <summary>
        /// returns index of the ComboboxItem content that similar to input word
        /// </summary>
        /// <param name="Choice">any ciombobox</param>
        /// <param name="word"> word that shold contains in combobox</param>
        /// <returns></returns>
        public static int ReturnIndex(ComboBox Choice,string word)
        {
            ComboBoxItem comboBoxItem; 
            for (int i = 0; i < Choice.Items.Count; i++)
            {
                comboBoxItem = (ComboBoxItem)Choice.Items[i];
                if(comboBoxItem.Content == word)
                {
                    return i;
                } 
            }
            return 0;
        }

        /// <summary>
        /// method that returns new book
        /// </summary>
        /// <returns></returns>
        public Book AddingBookMethod()
        {
            Book b1 = new Book(_title, _datePublisher, _publisher, convertToSerialNumber(_serialnumber), _country);
            b1.Genres= _gener;
            b1.Authors.Add(_author);
            b1.Synopsis = _synopsis;
            return b1;
        }

        /// <summary>
        /// method that returns new jornal
        /// </summary>
        /// <returns></returns>
        public Jornal AddingJornalMethod()
        {
            Jornal j1 = new Jornal(_title,_datePublisher,convertToPrice(_price),convertToSerialNumber(_serialnumber));
            j1.Ganers = _gener;
            j1.Editors = _publisher;
            j1.Contributers = _author;
            j1.Discount = Convert.ToInt32(_discount);
            return j1;
        }

      
    }
    
}
