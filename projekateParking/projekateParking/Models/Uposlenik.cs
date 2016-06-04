using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekateParking.Models
{
    public class Uposlenik : Osoba
    {
        public String username { get; set; }
        public String password { get; set; }

        public Uposlenik(String imePrezime, String brojLicneKarte, String JMBG, String brojTelefona, String adresa, String username, String password):
            base(imePrezime, brojLicneKarte, JMBG, brojTelefona, adresa)
        {
            this.username = username;
            this.password = password;
        }
    }
}
