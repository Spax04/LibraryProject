﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public sealed partial class MenengerPage : Page
    {
        public MenengerPage()
        {
            this.InitializeComponent();
        }

        private void btnJornalCol_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(JornalCollectionPage), null);
        }

        private void btnBookColl_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BookCollectionPage), null);
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainsPage),null);
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEmpSet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
