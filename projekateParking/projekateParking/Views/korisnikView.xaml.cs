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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace projekateParking.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class korisnikView : Page
    {
        private int i = 0;
        public korisnikView()
        {
            this.InitializeComponent();
            comboBoxTipPaketa.Items.Add("Satni");
            comboBoxTipPaketa.Items.Add("Dnevni");
            comboBoxTipPaketa.Items.Add("Mjesecni");
            comboBoxVrstaVozila.Items.Add("Automobil");
            comboBoxVrstaVozila.Items.Add("Kamion");
            comboBoxVrstaVozila.Items.Add("Autobus");
            textBlockDobrodoslica.Text = "Dobrodosao " + BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].imePrezime;
            if (BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].listaRegistracija.Count != 0) { 
                textBlockRegistracija.Text = BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].VratiRegistraciju(0);
                relativePanel.Visibility = Visibility.Visible;
             }
        }

        private void dugmeLogout_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(naslovna));
        }

        private void dugmeDodajRegistraciju_Click(object sender, RoutedEventArgs e)
        {
            String tipPaketa = comboBoxTipPaketa.SelectedItem.ToString();
            Boolean stalnoMjesto = (bool)checkBoxStalnoMjesto.IsChecked;
            String registarskeOznake = textBoxRegistarskeOznake.Text;
            String proizvodjacVozila = textBoxProizvodjacVozila.Text;
            String vrstaVozila = comboBoxVrstaVozila.SelectedItem.ToString();
            BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].dodajRegistraciju(new ViewModel.Registracija(new DateTime(), new DateTime(), tipPaketa, stalnoMjesto, new Models.Vozilo(registarskeOznake, 0, proizvodjacVozila, "", vrstaVozila)));
            i = BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].listaRegistracija.Count - 1;
            var s= BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].VratiRegistraciju(i);
            textBlockRegistracija.Text = BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].VratiRegistraciju(i);
            relativePanel.Visibility = Visibility.Visible;
        }

        private void dugmeSljedeca_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i >= BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].listaRegistracija.Count)
                i = 0;
            if (BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].listaRegistracija.Count != 0)
                textBlockRegistracija.Text = BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].VratiRegistraciju(i);
        }

        private void dugmePrethodna_Click(object sender, RoutedEventArgs e)
        {
            i--;
            if (i < 0)
                i = BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].listaRegistracija.Count - 1;
            if(BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].listaRegistracija.Count != 0)
                textBlockRegistracija.Text = BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].VratiRegistraciju(i);
        }
    }
}
