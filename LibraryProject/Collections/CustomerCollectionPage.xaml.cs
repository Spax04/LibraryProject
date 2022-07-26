using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Library.Model;
using Library.DAL;
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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerCollectionPage : Page
    {
        PersonRepository pr = new PersonRepository();
        public CustomerCollectionPage()
        {
            this.InitializeComponent();
            listMenuView.ItemsSource = pr.Get().Where(Item => Item is Customer);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Customer c1 = (Customer)listMenuView.SelectedItem;
            if(c1 != null)
            {
                custDitalsTxt.Text = c1.BookCustomerDitales();
            }
        }

        private async void btnRemoveBook_Click(object sender, RoutedEventArgs e)
        {
            Customer c1 = (Customer)listMenuView.SelectedItem;
            MessageDialog messageDialog = new MessageDialog("Are you sure you want to delete the book?");
            messageDialog.Commands.Clear();
            messageDialog.Commands.Add(new UICommand { Label = "Yes, delete", Id = 0 });
            messageDialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });

            var res = await messageDialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                pr.Delete(c1.Id);
            }

            listMenuView.ItemsSource = pr.Get().Where(Item => Item is Customer);
        }

        private void btnMenengerBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenengerPage));
        }
    }
}
