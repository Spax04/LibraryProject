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
    public sealed partial class MainsPage : Page
    {
        PersonRepository personRepository = new PersonRepository();
        Employee e1;
        public MainsPage()
        {
            this.InitializeComponent();
           
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            e1 = personRepository.GetbyLoginAndPassword(logintTxt.Text);
            if (e1 != null)
            {
                if(e1.Password == passwordTxt.Password)
                {
                    if(e1.IsMananger == true)
                    {
                        Frame.Navigate(typeof(MenengerPage),null);
                    }
                    else
                    {
                        Frame.Navigate(typeof(EmployeePage), null);
                    }
                }
                else
                {
                    issuesTxt.Text = "Wrong password";
                }
            }
            else
            {
                issuesTxt.Text = "Wrong login";
            }
        }
    }
}
