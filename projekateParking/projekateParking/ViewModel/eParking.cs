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
        public List<Korisnik> listaKorisnika;
        public Uposlenik upravnik = new Uposlenik("Samim Konjicija", "020K01817", "1304970110008", "062142224", "Ilidza 5", "skonjicija1", "glavninafaksu");

        public eParking()
        {
            listaKorisnika = new List<Korisnik>
            {
                new Korisnik("Samir Durakovic", "", "", "", "", false, "sdurakovic2", "000000")
            };
        }
        public void dodajKorisnika(String imePrezime, String brojLicneKarte, String JMBG, String brojTelefona, String adresa, Boolean specijalniKorisnik, String username, String password)
        {
            listaKorisnika.Add(new Korisnik(imePrezime, brojLicneKarte, JMBG, brojTelefona, adresa, specijalniKorisnik, username, password));
        }
        public int pronadjiKorisnika(String username)
        {
            for (int i = 0; i < listaKorisnika.Count; i++)
                if (username == listaKorisnika[i].username)
                    return i;
            return -1;
        }
        public void izbrisiKorisnika(String username)
        {
            int i = pronadjiKorisnika(username);
            listaKorisnika.Remove(listaKorisnika[i]);
        }
        public List<int> pronadjiKorisnikaIRegistraciju(string tablice)
        {
            int i=0, j=0;
            for(i = 0; i < listaKorisnika.Count(); i++)
                for(j = 0; j < listaKorisnika[i].listaRegistracija.Count(); j++)
                    if(listaKorisnika[i].listaRegistracija[j].vozilo.registarskeOznake == tablice)
                        return new List<int>(2){ i, j};
            return new List<int>(0);
        }
        //public Korisnik pronadjiKorisnika(String ID) { }
        //public String dajPasswordKorisnika(String username) { }

    }
}
