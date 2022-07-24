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
    public sealed partial class AddNewJornalPage : Page
    {
        
        LbraryRepository lb = new LbraryRepository();
        AddingNewLibraryItem adding;
        ComboBoxItem ci;
        Jornal j1;
        public AddNewJornalPage()
        {
            this.InitializeComponent();
            creatingCmbBookPage();
        }

        private void btnCheckFields_Click(object sender, RoutedEventArgs e)
        {
            adding = new AddingNewLibraryItem(titleTxt.Text, calendarPicker.Date.DateTime,priceTxt.Text,returnEnumValue(frequencyCmb), AddingNewLibraryItem.returnContent(generCmb),contributerTxt.Text,editorTxt.Text,serialNumberTxt.Text,discountTxt.Text);
            
            issuesTxt.Text = adding.checkingFieldsJornal(serialNumberTxt.Text,priceTxt.Text);
            if(issuesTxt.Text == "")
                btnAddNewBook.IsEnabled = true;
            else
                btnAddNewBook.IsEnabled = false;
        }
        public void updateJornal()
        {
            j1.Title = titleTxt.Text;
            j1.PublishDate = calendarPicker.Date.DateTime;
            j1.Price = Convert.ToDouble(priceTxt.Text);
            j1.SerialNumber = Convert.ToInt32(serialNumberTxt.Text);
            j1.Editors = editorTxt.Text;
            j1.Ganers = AddingNewLibraryItem.returnContent(generCmb);
            j1.Contributers = contributerTxt.Text;
            j1.Frequency = returnEnumValue(frequencyCmb);
            j1.Discount = Convert.ToDouble(discountTxt.Text);
        }
        private void creatingCmbBookPage()
        {
            for (int i = 0; i < Jornal.JornalGaners.Count; i++)
            {
                ci = new ComboBoxItem();
                ci.Content = Book.BookGenres[i];
                generCmb.Items.Add(ci);
            }

            var _enumval = Enum.GetValues(typeof(Jornal.JornalFrequency)).Cast<Jornal.JornalFrequency>();
            frequencyCmb.ItemsSource = _enumval.ToList();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                btnAddNewBook.Content = "Update";
                j1 = e.Parameter as Jornal;

                titleTxt.Text = j1.Title;
                calendarPicker.Date = j1.PublishDate;
                serialNumberTxt.Text = j1.SerialNumber.ToString();
                priceTxt.Text = j1.Price.ToString();
                editorTxt.Text = j1.Editors;
                generCmb.SelectedIndex = AddingNewLibraryItem.returnIndex(generCmb, j1.Ganers.ToString());
                contributerTxt.Text = j1.Contributers;
                
                discountTxt.Text = j1.Discount.ToString();
            }
        }
        public Jornal.JornalFrequency returnEnumValue(ComboBox cb)
        {
            Jornal.JornalFrequency jv = (Jornal.JornalFrequency)frequencyCmb.SelectedValue; ////!!!!!!!!!!!!!!!!
            return jv;
        }
        

        private void btnJornalViewBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(JornalCollectionPage), null, new EntranceNavigationTransitionInfo());
        }

        private void btnAddNewJornal_Click(object sender, RoutedEventArgs e)
        {
            if(j1 != null)
            {
                updateJornal();
                lb.Update(j1);
            }
            else
            {
                lb.Add(adding.addingJornalMethod());
            }
            Frame.Navigate(typeof(JornalCollectionPage), null, new EntranceNavigationTransitionInfo());
        }
    }
}
