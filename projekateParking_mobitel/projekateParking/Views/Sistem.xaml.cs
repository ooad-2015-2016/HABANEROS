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
using System.Threading.Tasks;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace projekateParking.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Sistem : Page
    {
        eParkingSistem sistem;
        public Sistem()
        {
            this.InitializeComponent();
            sistem = new eParkingSistem();
            BazaPodataka.Baza.sistemView = this;
        }

        private void buttonDolazak_Click(object sender, RoutedEventArgs e)
        {
            sistem.Pokreni(PreviewControl, 'U');
        }

        private void buttonNazad_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(naslovna));
        }
      

        private void buttonOdlazak_Click(object sender, RoutedEventArgs e)
        {
            sistem.Pokreni(PreviewControl, 'I');
        }
    }
}
