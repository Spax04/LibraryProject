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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmployeeCollectionPage : Page
    {
        PersonRepository pr = new PersonRepository();
        public EmployeeCollectionPage()
        {
            this.InitializeComponent();
            listMenuView.ItemsSource = pr.Get().Where(Item => Item is Employee).ToList();
        }

        private void btnMenengerBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenengerPage));
        }

        private async void btnRemoveCustomer_Click(object sender, RoutedEventArgs e)
        {
            Employee e1 = listMenuView.SelectedItem as Employee;

            MessageDialog messageDialog = new MessageDialog("Are you sure you want to delete the book?");
            messageDialog.Commands.Clear();
            messageDialog.Commands.Add(new UICommand { Label = "Yes, delete", Id = 0 });
            messageDialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });

            var res = await messageDialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                pr.Delete(e1.Id);
            }

            listMenuView.ItemsSource = pr.Get().Where(Item => Item is Employee).ToList();
        }
    }
}
