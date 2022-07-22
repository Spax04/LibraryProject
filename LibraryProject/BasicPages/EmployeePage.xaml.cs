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
    public sealed partial class EmployeePage : Page
    {
        LbraryRepository lb = new LbraryRepository();
        PersonRepository pr = new PersonRepository();

        public EmployeePage()
        {
            this.InitializeComponent();



            ListViewEmployee.ItemsSource = lb.Get();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainsPage),null);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if(radioButton != null)
            {
                string radio = radioButton.Tag.ToString();
                switch (radio)
                {
                    case "viewAll":
                        ListViewEmployee.ItemsSource = lb.Get().ToList();
                        break;
                    case "viewBook":
                        ListViewEmployee.ItemsSource = lb.Get().Where(Item => Item is Book);
                        break ;
                    case "viewJornal":
                        ListViewEmployee.ItemsSource = lb.Get().Where(Item => Item is Jornal);
                        break;
                        default:
                        ListViewEmployee.ItemsSource = lb.Get().ToList();
                        break;

                }
            }
            
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {

            Book b1 = ListViewEmployee.SelectedItem as Book;
            Jornal b2 = ListViewEmployee.SelectedItem as Jornal;
            if (b1 != null)
            {
                Frame.Navigate(typeof(LibraryItemDitalesPage), b1);
            }
            else if(b2 != null)
            {
                Frame.Navigate(typeof(LibraryItemDitalesPage), b2);
            }
        }

        private void sorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (sorting.SelectedIndex)
            {
                case 0:
                    ListViewEmployee.ItemsSource = lb.GetSortBy(new SortLibraryItemsByName());
                    break;
                case 1:
                    ListViewEmployee.ItemsSource = lb.GetSortBy(new SortLibraryItemsByYear());
                    break;
                
            }
        }
    }
}
