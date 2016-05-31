using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekateParking.ViewModel
{
    enum PackageType { }
    class Registracija
    {
        public String ID { get; set; }
        public DateTime datumRegistracije { get; }
        public DateTime datumIstekaRegistracije { get; set; }
        public PackageType tipPaketa { get; set; }
        public Boolean stalnoMjesto { get; set; }
        public Boolean specijalniKorisnik { get; set; }

        Registracija(String ID, DateTime datumRegistracije, DateTime datumIstekaRegistracije, PackageType tipPaketa, Boolean stalnoMjesto, bool specijalniKorisnik)
        {
            this.ID = ID;
            this.datumIstekaRegistracije = datumIstekaRegistracije;
            this.datumRegistracije = datumRegistracije;
            this.tipPaketa = tipPaketa;
            this.stalnoMjesto = stalnoMjesto;
            this.specijalniKorisnik = specijalniKorisnik;
        }


    }
}
