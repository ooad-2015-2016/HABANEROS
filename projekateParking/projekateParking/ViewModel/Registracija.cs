using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekateParking.Models;

namespace projekateParking.ViewModel
{
    public class Registracija
    {
        static int IDsljedeci = 1;
        public Vozilo vozilo { get; set; }
        public int ID { get; set; }
        public DateTime datumRegistracije { get; }
        public DateTime datumIstekaRegistracije { get; set; }
        public String tipPaketa { get; set; }
        public Boolean stalnoMjesto { get; set; }
        public List<SesijaOKoristenjuParkinga> sesijaokoristenjuparkinga;
        

        public Registracija(DateTime datumRegistracije, DateTime datumIstekaRegistracije, String tipPaketa, Boolean stalnoMjesto, Vozilo vozilo)
        {
            this.ID = IDsljedeci++;
            this.datumIstekaRegistracije = datumIstekaRegistracije;
            this.datumRegistracije = datumRegistracije;
            this.tipPaketa = tipPaketa;
            this.stalnoMjesto = stalnoMjesto;
            this.vozilo = vozilo;
            sesijaokoristenjuparkinga = new List<SesijaOKoristenjuParkinga>(0);
        }
        public void dodajSesiju(SesijaOKoristenjuParkinga sesija)
        {
            sesijaokoristenjuparkinga.Add(sesija);
        }
        public int zatvoriSesiju()
        {
            sesijaokoristenjuparkinga[sesijaokoristenjuparkinga.Count() - 1].vrijemeOdlaska = DateTime.Now;
            return sesijaokoristenjuparkinga[sesijaokoristenjuparkinga.Count - 1].mjesto;
        }
    }
}
