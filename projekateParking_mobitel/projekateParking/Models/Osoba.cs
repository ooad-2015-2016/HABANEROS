using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekateParking.Models
{
    public abstract class Osoba
    {
        public String imePrezime { get; set; }
        public String brojLicneKarte { get; set; }
        public String JMBG { get; set; }
        public String brojTelefona { get; set; }
        public String adresa { get; set; }

        protected Osoba()
        { }
        protected Osoba(String imePrezime, String brojLicneKarte, String JMBG, String brojTelefona, String adresa)  
        {
            this.imePrezime = imePrezime;
            this.brojLicneKarte = brojLicneKarte;
            this.JMBG = JMBG;
            this.brojTelefona = brojTelefona;
            this.adresa = adresa;
        }
    }
}
