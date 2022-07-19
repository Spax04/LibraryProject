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
    public sealed partial class JornalCollectionPage : Page
    {
        LbraryRepository lb;
        public JornalCollectionPage()
        {
            this.InitializeComponent();
            lb = new LbraryRepository();
            listMenuView.ItemsSource = lb.GetJornal();
        }

       

        private void btnBookViewBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null, new EntranceNavigationTransitionInfo());
        }

        private async void btnRemoveJornal_Click(object sender, RoutedEventArgs e)
        {
            int itemIndex = listMenuView.SelectedIndex;
            Jornal b1 = listMenuView.SelectedItem as Jornal;

            MessageDialog messageDialog = new MessageDialog("Are you sure you want to delete the book?");
            messageDialog.Commands.Clear();
            messageDialog.Commands.Add(new UICommand { Label = "Yes, delete", Id = 0 });
            messageDialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });

            var res = await messageDialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                lb.DeleteJornal(b1.Id);
            }

            listMenuView.ItemsSource = lb.GetJornal();
        }
    }
}
