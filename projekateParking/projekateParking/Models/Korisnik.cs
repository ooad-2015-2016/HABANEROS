using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekateParking.ViewModel;
namespace projekateParking.Models
{
    class Korisnik : Osoba
    {
        public String ID { get; set; }
        public Boolean specijalniKorisnik { get; set; }
        private List<Registracija> listaRegistracija;

        public Korisnik()
        { }
        public Korisnik(String ID, String imePrezime, String brojLicneKarte, String JMBG, String brojTelefona, String adresa, Boolean specijalniKorisnik)
            :base(imePrezime, brojLicneKarte, JMBG, brojTelefona, adresa)
        {
            this.ID = ID;
            this.specijalniKorisnik = specijalniKorisnik;
        }

        public void dodajRegistraciju() { }
        public void izbrisiRegistraciju(String ID) { }
    }
}
