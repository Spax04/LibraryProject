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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BookCollectionPage : Page
    {
        public LbraryRepository lb;
        public BookCollectionPage()
        {

            this.InitializeComponent();
           lb = new LbraryRepository();
            // for(int i = 0; i < books.Count; i++)
            listMenuView.ItemsSource = lb.GetBook();

            
        }

        private void btnBookViewBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null, new EntranceNavigationTransitionInfo());
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddNewBookPage), null, new EntranceNavigationTransitionInfo());
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    listMenuView.ItemsSource = lb.GetSortBookBy(new SortLibraryItemsByName());
                    break;                               
                case 1:                                  
                    listMenuView.ItemsSource = lb.GetSortBookBy(new SortLibraryItemsByYear());
                    break;                               
                case 2:                                  
                    listMenuView.ItemsSource = lb.GetSortBookBy(new SortLIbraryItemsByCountry());
                    break;
            }
          
        }

        private async void btnRemoveBook_Click(object sender, RoutedEventArgs e)
        {
            int itemIndex = listMenuView.SelectedIndex;
            Book b1 = listMenuView.SelectedItem as Book;
            

            MessageDialog messageDialog = new MessageDialog("Are you sure you want to delete the book?");
            messageDialog.Commands.Clear();
            messageDialog.Commands.Add(new UICommand { Label = "Yes, delete", Id = 0 });
            messageDialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            
            var res = await messageDialog.ShowAsync();

            if((int)res.Id == 0)
            {
                lb.DeleteBook(b1.Id);
            }
            
            listMenuView.ItemsSource = lb.GetBook();
        }

    }
}
