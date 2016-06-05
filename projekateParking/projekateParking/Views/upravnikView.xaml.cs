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
using projekateParking.BazaPodataka;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace projekateParking.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class upravnikView : Page
    {
        private int ikorisnik = 0, iregistracija = 0, isesija = 0;
        public upravnikView()
        {
            this.InitializeComponent();
            textBlockDobrodoslica.Text = "Dobrodošao " + BazaPodataka.Baza.sistem.upravnik.imePrezime;
            textBlockSesija.Text = "";
            textBlockBrojKorisnika.Text = BazaPodataka.Baza.sistem.listaKorisnika.Count.ToString();
            int brojRegistracija = 0;
            int brojSesija = 0;
            for (int i = 0; i < BazaPodataka.Baza.sistem.listaKorisnika.Count; i++)
            {
                brojRegistracija += BazaPodataka.Baza.sistem.listaKorisnika[i].listaRegistracija.Count;
                for (int j = 0; j < BazaPodataka.Baza.sistem.listaKorisnika[i].listaRegistracija.Count; j++)
                {
                    brojSesija += BazaPodataka.Baza.sistem.listaKorisnika[i].listaRegistracija[j].sesijaokoristenjuparkinga.Count;
                    for (int k = 0; k < BazaPodataka.Baza.sistem.listaKorisnika[i].listaRegistracija[j].sesijaokoristenjuparkinga.Count; k++)
                    {
                        textBlockSesija.Text = BazaPodataka.Baza.sistem.listaKorisnika[i].listaRegistracija[j].VratiSesiju(k);
                        ikorisnik = i;
                        iregistracija = j;
                        isesija = k;
                    }
                }

            }

            textBlockBrojRegistracija.Text = brojRegistracija.ToString();
            textBlockBrojSesija.Text = brojSesija.ToString();


            if (textBlockSesija.Text != "")
            {
                relativePanel.Visibility = Visibility.Visible;
            }
        }

        private void dugmeLogout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(naslovna));
        }

        private void dugmePrethodna_Click(object sender, RoutedEventArgs e)
        {
            isesija--;
            while(isesija < 0)
            {
                iregistracija--;
                while(iregistracija < 0)
                {
                    ikorisnik--;
                    if(ikorisnik < 0)
                    {
                        ikorisnik = Baza.sistem.listaKorisnika.Count() - 1;
                    }
                    iregistracija = Baza.sistem.listaKorisnika[ikorisnik].listaRegistracija.Count() - 1;
                }
                isesija = Baza.sistem.listaKorisnika[ikorisnik].listaRegistracija[iregistracija].sesijaokoristenjuparkinga.Count() - 1;
            }
            textBlockSesija.Text = Baza.sistem.listaKorisnika[ikorisnik].listaRegistracija[iregistracija].VratiSesiju(isesija);
        }

        private void dugmeSljedeca_Click(object sender, RoutedEventArgs e)
        {
            isesija++;
            while(isesija >= Baza.sistem.listaKorisnika[ikorisnik].listaRegistracija[iregistracija].sesijaokoristenjuparkinga.Count())
            {
                isesija = 0;
                iregistracija++;
                while(iregistracija >= Baza.sistem.listaKorisnika[ikorisnik].listaRegistracija.Count())
                {
                    iregistracija = 0;
                    ikorisnik++;
                    if (ikorisnik >= Baza.sistem.listaKorisnika.Count())
                        ikorisnik = 0;
                } 
            }
            textBlockSesija.Text = Baza.sistem.listaKorisnika[ikorisnik].listaRegistracija[iregistracija].VratiSesiju(isesija);
        }

        private void dugmeObrisiKorisnika_Click(object sender, RoutedEventArgs e)
        {
            String username = textBoxUsername.Text;
            String greska;
            if (BazaPodataka.Baza.sistem.pronadjiKorisnika(username) == -1)
            {
                greska = "*Ne postoji korisnik sa tim Username-om\n";
            }
            else
            {
                BazaPodataka.Baza.sistem.izbrisiKorisnika(username);
                greska = "*Korisnik uspješno obrisan!\n";
            }
            textBlockGreska.Text = greska;
            textBlockGreska.Visibility = Visibility.Visible;
            textBlockBrojKorisnika.Text = BazaPodataka.Baza.sistem.listaKorisnika.Count.ToString();
            int brojRegistracija = 0;
            int brojSesija = 0;
            for (int i = 0; i < BazaPodataka.Baza.sistem.listaKorisnika.Count; i++)
            {
                brojRegistracija += BazaPodataka.Baza.sistem.listaKorisnika[i].listaRegistracija.Count;
                for (int j = 0; j < BazaPodataka.Baza.sistem.listaKorisnika[i].listaRegistracija.Count; j++)
                {
                    brojSesija += BazaPodataka.Baza.sistem.listaKorisnika[i].listaRegistracija[j].sesijaokoristenjuparkinga.Count;
                    for (int k = 0; k < BazaPodataka.Baza.sistem.listaKorisnika[i].listaRegistracija[j].sesijaokoristenjuparkinga.Count; k++)
                    {
                        textBlockSesija.Text = BazaPodataka.Baza.sistem.listaKorisnika[i].listaRegistracija[j].VratiSesiju(k);
                        ikorisnik = i;
                        iregistracija = j;
                        isesija = k;
                    }
                }
            }
            textBlockBrojSesija.Text = brojSesija.ToString();
            textBlockBrojRegistracija.Text = brojRegistracija.ToString();
            if (brojSesija == 0) relativePanel.Visibility = Visibility.Collapsed;
        }
    }
}
