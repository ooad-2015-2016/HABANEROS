using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekateParking.Models
{
    class Uposlenik : Osoba
    {
        public String ID { get; set; }

        Uposlenik(String imePrezime, String brojLicneKarte, String JMBG, String brojTelefona, String adresa, String ID):
            base(imePrezime, brojLicneKarte, JMBG, brojTelefona, adresa)
        {
            this.ID = ID;
        }
    }
}
