using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekateParking.ViewModel;
namespace projekateParking.Models
{
    public class Korisnik : Osoba
    {
        public Boolean specijalniKorisnik { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public List<Registracija> listaRegistracija;

        public Korisnik()
        { }
        public Korisnik(String imePrezime, String brojLicneKarte, String JMBG, String brojTelefona, String adresa, Boolean specijalniKorisnik, String username, String password)
            :base(imePrezime, brojLicneKarte, JMBG, brojTelefona, adresa)
        {
            this.specijalniKorisnik = specijalniKorisnik;
            this.username = username;
            this.password = password;
            listaRegistracija = new List<Registracija>(0);
        }

        public void dodajRegistraciju(Registracija registracija)
        {
            listaRegistracija.Add(registracija);
        }

        public void izbrisiRegistraciju(int ID)
        {
            
        }

        public string VratiRegistraciju(int index)
        {
            string povratak = "";
            povratak = "ID:\t";
            povratak += this.listaRegistracija[index].ID.ToString() + "\n";
            povratak += "Tip paketa:\t";
            povratak += this.listaRegistracija[index].tipPaketa + "\n";
            povratak += "Stalno mjesto:\t";
            if (this.listaRegistracija[index].stalnoMjesto)
                povratak += "DA\n";
            else
                povratak += "NE\n";
            povratak += "\nPodaci o vozilu:\n";
            povratak += "Registarske oznake:\t";
            povratak += this.listaRegistracija[index].vozilo.registarskeOznake + "\n";
            povratak += "Proizvodjac:\t";
            povratak += this.listaRegistracija[index].vozilo.proizvodjac + "\n";
            return povratak;
        }
    }
}
