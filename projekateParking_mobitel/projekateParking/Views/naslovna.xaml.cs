using System;
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
using projekateParking.ViewModel;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace projekateParking.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class naslovna : Page
    {
        //SerialPort serial;
        public naslovna()
        {
            this.InitializeComponent();
        }

        private void dugmeRegistriraj_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(registracijaKorisnika));
        }
        private void dugmeLogin_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(login));
        }

        private void dugmeSistem_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Sistem));
        }
    }
}
