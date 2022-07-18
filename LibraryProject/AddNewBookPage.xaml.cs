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
        AddingNewBookClass adding;
        public AddNewBookPage()
        {
            this.InitializeComponent();


           
            // LbraryRepository.Add(new Book());


        }

        private void btnCheckFields_Click(object sender, RoutedEventArgs e)
        {
            

            adding = new AddingNewBookClass(titleTxt.Text, publishDateTxt.Text, publisherTxt.Text, serialNumberTxt.Text, countryTxt.Text);
            issuesTxt.Text = adding.checkingFields(publishDateTxt.Text, serialNumberTxt.Text);
           if(issuesTxt.Text == "")
            {
                btnAddNewBook.IsEnabled = true;
            }
            else
            {
                btnAddNewBook.IsEnabled = false;
            }
           
        }

        private void btnAddNewBook_Click(object sender, RoutedEventArgs e)
        {
            adding = new AddingNewBookClass(titleTxt.Text, publishDateTxt.Text, publisherTxt.Text, serialNumberTxt.Text, countryTxt.Text);
            lb.Add(adding.addingBookMethod());
        }

        private void btnBookViewBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BookCollectionPage), null, new EntranceNavigationTransitionInfo());
        }
    }
}
