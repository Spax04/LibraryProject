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
using Windows.UI;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LibraryItemDitalesPage : Page
    {
        PersonRepository pr = new PersonRepository();
        LbraryRepository lb = new LbraryRepository();
        LibraryItem b1;
        public LibraryItemDitalesPage()
        {
            this.InitializeComponent();
            ListCustomers.ItemsSource = pr.Get().Where(Item => Item is Customer);

            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {  
            if (e.Parameter != null)
            {
                b1 = e.Parameter as LibraryItem;
                liInfoTxt.Text = b1.Ditales();
                if (liInfoTxt.Text.Contains("Jornal") == true)
                {
                    btnGrid.Children.Remove(btnOutOfStock);
                    btnGrid.Children.Remove(btnReturn);
                    gridPanel.Children.Remove(ListCustomers);

                }
                else
                {
                    btnGrid.Children.Remove(btnSell);
                }
                    checkingStatus(b1);
            }
        }

        private void btnOutOfStock_Click(object sender, RoutedEventArgs e)
        {
            Customer person = ListCustomers.SelectedItem as Customer;
            
            if(person != null)
            {
                person.customerItems.Add(b1);
                b1.OutOfStockLI(person);
                lb.Update(b1);
                pr.Update(person);
                checkingStatus(b1);
            }
        }
        private void btnReturnItem_Click(object sender, RoutedEventArgs e)
        {
            Customer c1 = b1.BackInStockLI();
            c1.customerItems.Remove(b1);
            checkingStatus(b1);
        }
        public void checkingStatus(LibraryItem b1)
        {
            if (b1.InStock)
            {
                statusTxt.Text = "IN STOCK";
                rectStatus.Fill = new SolidColorBrush(Colors.Green);
                btnOutOfStock.IsEnabled = true;
                btnReturn.IsEnabled = false;
            }
            else
            {
                statusTxt.Text = "OUT OF STOCK";
                rectStatus.Fill = new SolidColorBrush(Colors.Red);
                btnOutOfStock.IsEnabled = false;
                btnReturn.IsEnabled = true;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeePage));
        }

        private void btnSellItem_Click(object sender, RoutedEventArgs e)
        {
            b1.SellItem();
            lb.Delete(b1.Id);
            checkingStatus(b1);
            btnReturn.IsEnabled = false;
        }

        
    }
}
