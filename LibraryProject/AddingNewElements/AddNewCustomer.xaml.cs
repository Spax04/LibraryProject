using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Library.DAL;
using Library.Model;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewCustomer : Page
    {
        PersonRepository pr = new PersonRepository();
        AddingNewPerson adding;
        public AddNewCustomer()
        {
            this.InitializeComponent();
        }

        private void btnCheckFields_Click(object sender, RoutedEventArgs e)
        {
            adding = new AddingNewPerson(fNameTxt.Text,lNameTxt.Text,Phone.Text);
            issuesTxt.Text = adding.CheckingFieldsCustumer();
            if(issuesTxt.Text == "")
            {
                btnAddCust.IsEnabled = true;
            }
            else
            {
                btnAddCust.IsEnabled = false;
            }
        }

        private void AddCust(object sender, RoutedEventArgs e)
        {
            pr.Add(adding.RegistrCustomer());
            Frame.Navigate(typeof(MenengerPage));
        }

        private void btnMenengerBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenengerPage));
        }
    }
}
