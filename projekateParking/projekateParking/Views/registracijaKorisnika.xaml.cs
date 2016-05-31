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
using projekateParking.BazaPodataka;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace projekateParking.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class registracijaKorisnika : Page
    {
        static int sljedeciID = 0;

        public registracijaKorisnika()
        {
            this.InitializeComponent();
        }

        private void dugmeNazad_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(naslovna));
        }

        private void dugmeSpremi_Click(object sender, RoutedEventArgs e)
        {
            Boolean flag = false;
            String greska = "";
            String imePrezime = TextBoxImePrezime.Text;
            String brojLicneKarte = TextBoxBrojLicneKarte.Text;
            String JMBG = TextBoxJMBG.Text;
            String brojTelefona = TextBoxBrojTelefona.Text;
            String adresa = TextBoxAdresa.Text;
            Boolean specijalniKorisnik = checkBoxInvalid.IsChecked.Value | checkBoxPenzioner.IsChecked.Value;
            String username = TextBoxUsername.Text;
            String password = passwordBox.Password;

            // Provjera ime i prezime
            if (String.IsNullOrWhiteSpace(imePrezime))
            {
                greska += "*Niste unijeli ime i prezime\n";
                flag = true;
            }
            else
            {
                String provjera = imePrezime.ToUpper();
                for (int i = 0; i < imePrezime.Length; i++)
                {
                    if ((provjera[i] < 'A' || provjera[i] > 'Z') && provjera[i] != ' ')
                    {
                        greska += "*Neispravno ime i prezime\n";
                        flag = true;
                        break;
                    }
                }
            }

            // Provjera broj licne karte
            if(String.IsNullOrWhiteSpace(brojLicneKarte))
            {
                greska += "*Niste unijeli broj licne karte\n";
                flag = true;
            }
            else if(brojLicneKarte.Length != 9)
            {
                greska += "*Neispravan broj licne karte\n";
                flag = true;
            }
           
            else
                for(int i = 0; i < 9; i++)
                    if((brojLicneKarte[i] < 'A' || brojLicneKarte[i] > 'Z') && (brojLicneKarte[i] < '0' || brojLicneKarte[i] > '9'))
                    {
                        greska += "*Neispravan broj licne karte\n";
                        flag = true;
                        break;
                    }
            
            // Provjera JMBG

            if(String.IsNullOrWhiteSpace(JMBG))
            {
                greska += "*Niste unijeli JMBG\n";
                flag = true;
            }
            else if(JMBG.Length != 13)
            {
                greska += "*Neispravan JMBG\n";
                flag = true;
            }
            else
            {
                for(int i = 0; i < JMBG.Length; i++)
                    if(JMBG[i] < '0' || JMBG[i] > '9')
                    {
                        greska = "*Neispravan JMBG\n";
                        flag = true;
                        break;
                    }
            }

            // provjera broja telefona

            if (String.IsNullOrWhiteSpace(brojTelefona))
            {
                greska += "*Niste unijeli broj telefona\n";
                flag = true;
            }
            else
            {
                for (int i = 0; i < brojTelefona.Length; i++)
                    if (brojTelefona[i] < '0' || brojTelefona[i] > '9')
                    {
                        greska = "*Neispravan broj telefona\n";
                        flag = true;
                        break;
                    }
            }

            // provjera adrese

            if(String.IsNullOrWhiteSpace(adresa))
            {
                greska += "*Niste unijeli adresu\n";
                flag = true;
            }

            // provjera username

            if (String.IsNullOrWhiteSpace(username))
            {
                greska += "*Niste unijeli username\n";
                flag = true;
            }
            else
            {

            }

            // provjera password 

            if (String.IsNullOrWhiteSpace(password))
            {
                greska += "*Niste unijeli password\n";
                flag = true;
            }
            else if(password.Length < 6)
            {
                greska += "*Prekratak password\n";
                flag = true;
            }

            if (!flag)
            {
                String ID = "K" + sljedeciID.ToString();
                Baza.sistem.dodajKorisnika(ID,imePrezime, brojLicneKarte, JMBG, brojTelefona, adresa, specijalniKorisnik);
                sljedeciID++;
                Frame.Navigate(typeof(naslovna));
                
            }
            else
            {
                textBlockGreska.Text = greska;
                textBlockGreska.Visibility = Visibility.Visible;
            }

        }
    }
}
