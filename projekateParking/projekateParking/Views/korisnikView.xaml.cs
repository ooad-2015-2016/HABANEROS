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
            comboBoxTipPaketa.SelectedItem = "Satni";
            comboBoxVrstaVozila.Items.Add("Automobil");
            comboBoxVrstaVozila.Items.Add("Kamion");
            comboBoxVrstaVozila.Items.Add("Autobus");
            comboBoxVrstaVozila.SelectedItem = "Automobil";
            textBlockDobrodoslica.Text = "Dobrodošao " + BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].imePrezime;
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
            bool flag = false;
            string greska = "";

            if (registarskeOznake == "")
            {
                greska += "*Niste unijeli registarske oznake";
                flag = true;
            }
            else if (registarskeOznake.Count() != 9)
            {
                greska += "*Pogresne registarske oznake\n";
                flag = true;
            }
            else
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 3 || j == 5) {
                        if (registarskeOznake[j] != '-')
                        {
                            greska += "*Pogresne registarske oznake\n";
                            flag = true;
                            break;
                        }
                    }
                    else if (j == 0 || j == 4) {
                        if ((registarskeOznake[j] < 'A' || registarskeOznake[j] > 'Z'))
                        {
                            greska += "*Pogresne registarske oznake\n";
                            flag = true;
                            break;
                        }
                    }
                    else if (registarskeOznake[j] < '0' && registarskeOznake[j] > '9')
                    {
                        greska += "*Pogresne registarske oznake\n";
                        flag = true;
                        break;
                    } 
                }
            }
            if(proizvodjacVozila == "")
            {
                greska += "*Niste unijeli proizvodjaca vozila\n";
                flag = true;
            }
            if (!flag)
            {
                BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].dodajRegistraciju(new ViewModel.Registracija(new DateTime(), new DateTime(), tipPaketa, stalnoMjesto, new Models.Vozilo(registarskeOznake, 0, proizvodjacVozila, "", vrstaVozila)));
                i = BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].listaRegistracija.Count - 1;
                var s = BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].VratiRegistraciju(i);
                textBlockRegistracija.Text = BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].VratiRegistraciju(i);
                relativePanel.Visibility = Visibility.Visible;

                textBlockGreska.Visibility = Visibility.Collapsed;
                textBoxProizvodjacVozila.Text = "";
                textBoxRegistarskeOznake.Text = "";
            }
            else
            {
                textBlockGreska.Text = greska;
                textBlockGreska.Visibility = Visibility.Visible;
            }
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

        private void dugmeOdjaviRegistraciju_Click(object sender, RoutedEventArgs e)
        {
            if (BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].listaRegistracija.Count > 0)
            {
                BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].izbrisiRegistraciju(i);
                if(BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].listaRegistracija.Count <= 0)
                {
                    i = 0;
                    relativePanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    i--;
                    if (i < 0)
                        i = BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].listaRegistracija.Count - 1;
                    if (BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].listaRegistracija.Count != 0)
                        textBlockRegistracija.Text = BazaPodataka.Baza.sistem.listaKorisnika[BazaPodataka.Baza.index].VratiRegistraciju(i);
                }
            }
        }
    }
}
