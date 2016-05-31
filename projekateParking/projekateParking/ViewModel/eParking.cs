using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekateParking.Models;

namespace projekateParking.ViewModel
{
    public class eParking
    {
        private List<Korisnik> listaKorisnika;

        public eParking() { listaKorisnika = new List<Korisnik>(); }
        public void dodajKorisnika(String ID, String imePrezime, String brojLicneKarte, String JMBG, String brojTelefona, String adresa, Boolean specijalniKorisnik)
        {
            listaKorisnika.Add(new Korisnik(ID, imePrezime, brojLicneKarte, JMBG, brojTelefona, adresa, specijalniKorisnik));
        }
        public void izbrisiKorisnika(String ID)
        {

        }
        //public Korisnik pronadjiKorisnika(String ID) { }
        //public String dajPasswordKorisnika(String username) { }

    }
}
