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
        LbraryRepository lbRep = new LbraryRepository();
        PersonRepository prRep = new PersonRepository();

        public EmployeePage()
        {
            this.InitializeComponent();



            ListViewEmployee.ItemsSource = lbRep.Get();
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
                        ListViewEmployee.ItemsSource = lbRep.Get().ToList();
                        break;
                    case "viewBook":
                        ListViewEmployee.ItemsSource = lbRep.Get().Where(Item => Item is Book);
                        break ;
                    case "viewJornal":
                        ListViewEmployee.ItemsSource = lbRep.Get().Where(Item => Item is Jornal);
                        break;
                        default:
                        ListViewEmployee.ItemsSource = lbRep.Get().ToList();
                        break;

                }
            }
            
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            int itemIndex = ListViewEmployee.SelectedIndex;
            LibraryItem b1 = ListViewEmployee.SelectedItem as LibraryItem;
            Frame.Navigate (typeof(LibraryItemDitalesPage),b1);
        }
    }
}
