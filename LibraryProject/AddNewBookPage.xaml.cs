using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Library.DAL;
using Library.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Animation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewBookPage : Page
    {
        LbraryRepository lb = new LbraryRepository();
        AddingNewLibraryItem adding;
        ComboBoxItem ci;
        public AddNewBookPage()
        {
            this.InitializeComponent();

            creatingCmbBookPage();
        }

        private void btnCheckFields_Click(object sender, RoutedEventArgs e)
        {
            adding = new AddingNewLibraryItem(titleTxt.Text, calendarPicker.Date.DateTime, AddingNewLibraryItem.returnContent(publisherCmb), serialNumberTxt.Text, AddingNewLibraryItem.returnContent(countrCmb), AddingNewLibraryItem.returnContent(generCmb), authorTxt.Text);
            issuesTxt.Text = adding.checkingFields( serialNumberTxt.Text);
           if(issuesTxt.Text == "")
                btnAddNewBook.IsEnabled = true;
            else
                btnAddNewBook.IsEnabled = false;
           
        }

        private void btnAddNewBook_Click(object sender, RoutedEventArgs e)
        {
            lb.AddBook(adding.addingBookMethod());
            Frame.Navigate(typeof(BookCollectionPage), null, new EntranceNavigationTransitionInfo());
        }

        private void btnBookViewBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BookCollectionPage), null, new EntranceNavigationTransitionInfo());
        }

        private void creatingCmbBookPage()
        {
            for (int i = 0; i < Book.BookGenres.Count; i++)
            {
                ci = new ComboBoxItem();
                ci.Content = Book.BookGenres[i];
                generCmb.Items.Add(ci);
            }

            Dictionary<string, int>.KeyCollection countryKeys = ISBN.Countries.Keys;
            foreach (var item in countryKeys)
            {
                ComboBoxItem ci = new ComboBoxItem();
                ci.Content = item;
                
                countrCmb.Items.Add(ci);
            }

            Dictionary<string, int>.KeyCollection publisherKeys = ISBN.Publishers.Keys;
            foreach (var item in publisherKeys)
            {
                ComboBoxItem ci = new ComboBoxItem();
                ci.Content = item;
                publisherCmb.Items.Add(ci);
            }
        }

       
    }
}
