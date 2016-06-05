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
    public sealed partial class login : Page
    {
        public login()
        {
            this.InitializeComponent();
        }

        private void dugmeLogin_Click(object sender, RoutedEventArgs e)
        {
            String username = textBoxUsername.Text;
            String password = passwordBox.Password;
            Boolean flag = false;
            String greska = "";
            Boolean daLiJeUpravnik = false;
            Boolean daLiJeKorisnik = false;


            // provjera da li su uneseni podaci

            if (String.IsNullOrWhiteSpace(username))
            {
                greska += "*Niste unijeli username\n";
                flag = true;
            }

            if (String.IsNullOrWhiteSpace(password))
            {
                greska += "*Niste unijeli password\n";
                flag = true;
            }

            if ((bool)(!radioButtonKorisnik.IsChecked & !radioButtonUposlenik.IsChecked))
            {
                greska += "*Niste naznacili vrstu prijave\n";
                flag = true;
            }

            //provjera validnosti upravnik

            daLiJeUpravnik = (Boolean)radioButtonUposlenik.IsChecked;
            if(!flag)
            {
                if (daLiJeUpravnik)
                {
                    if (username != BazaPodataka.Baza.sistem.upravnik.username)
                    {
                        greska += "*Pogresan username\n";
                        flag = true;
                    }
                    else
                    {
                        if (password != BazaPodataka.Baza.sistem.upravnik.password)
                        {
                            greska += "*Pogresab password\n";
                            flag = true;
                        }
                        else
                        {
                            //Frame.Navigate(typeof(upravnikView));
                        }
                    }
                }
            }

            // Provjera validnosti korisnika

            daLiJeKorisnik = (Boolean)radioButtonKorisnik.IsChecked;

            if(!flag)
            {
                if(daLiJeKorisnik)
                {
                    int indeks = BazaPodataka.Baza.sistem.pronadjiKorisnika(username);
                    if (indeks == -1)
                    {
                        greska += "*Korisnik ne postoji\n";
                        flag = true;
                    }
                    else if (username != BazaPodataka.Baza.sistem.listaKorisnika[indeks].username)
                    {
                        greska += "*Pogresan username\n";
                        flag = true;
                    }
                    else
                    {
                        if(password != BazaPodataka.Baza.sistem.listaKorisnika[indeks].password)
                        {
                            greska += "*Pogresan password\n";
                            flag = true;
                        }
                        else
                        {
                            BazaPodataka.Baza.index = indeks;
                            //Frame.Navigate(typeof(korisnikView));
                        }
                    }
                }
            }
            if(flag)
            {
                textBlockGreska.Text = greska;
                textBlockGreska.Visibility = Visibility.Visible;
            }
        }

        private void dugmeNazad_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(naslovna));
        }
        
    }
}
