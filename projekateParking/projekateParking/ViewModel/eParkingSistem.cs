﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using projekateParking.BazaPodataka;
using projekateParking.Views;

namespace projekateParking.ViewModel
{
    public class eParkingSistem
    {
        private Arduino arduino;
        private PrepoznavanjeTablica prepoznavanjeTablica;

        public eParkingSistem()
        {
            Baza.listaMjesta = new List<bool>(100);
            arduino = new Arduino();
        }
        public async void Pokreni(CaptureElement PreviewControl, char slovo)
        {
            //Task.Delay(2000).Wait();
            //otvoriIzlaznuRampu();
            char recenica = slovo;//= arduino.ucitajZnak();
            if (recenica == 'U' || recenica == 'I')
            {
                var Kamera = new Kamera();
                await Kamera.UcitajKameru(PreviewControl);      //KAMERA
                Task.Delay(2000).Wait();
                await Kamera.TakePhotoAsync();
                string imeslike = Kamera.DajImeSlike();
                prepoznavanjeTablica = new PrepoznavanjeTablica(imeslike);
                await prepoznavanjeTablica.prepoznajTablice();
                string tablice = prepoznavanjeTablica.dajTablice();
                string poruka = "REGISTARSKE OZNAKE: " + tablice;
               // Sistem.postaviPoruku(poruka);
                Task.Delay(3000).Wait();
                List<int> prik = Baza.sistem.pronadjiKorisnikaIRegistraciju(tablice);
                if (recenica == 'U' && prik.Count() > 0)///if() u bazi podataka zapocni sesiju i otvori ulaznu rampu
                {
                    otvoriUlaznuRampu();
                    int mjesto = zauzmiMjesto();
                    Baza.sistem.listaKorisnika[prik[0]].listaRegistracija[prik[1]].dodajSesiju(new SesijaOKoristenjuParkinga(DateTime.Now, mjesto));
                    zatvoriUlaznuRampu();
                    Task.Delay(2000).Wait();
                   // Sistem.postaviSesiju("Sesija otvorena.");
                }
                else if (recenica == 'I' && prik.Count() > 0)///u bazi podataka zatvori sesiju i otvori izlaznu rampu
                {
                    otvoriIzlaznuRampu();
                    int mjesto = Baza.sistem.listaKorisnika[prik[0]].listaRegistracija[prik[1]].zatvoriSesiju();
                    oslobodiMjesto(mjesto);
                    zatvoriIzlaznuRampu();
                    Task.Delay(2000).Wait();
                    //Sistem.postaviSesiju("Sesija zatvorena.");
                }
                else ///else usmjeri na registraciju
                {
                    Debug.WriteLine(tablice);
                    //Sistem.postaviSesiju("Molimo registrujte se, hvala.");
                }
                Task.Delay(3000).Wait();
                //Sistem.postaviPoruku("");
                //Sistem.postaviSesiju("");
            }
        }
        public void otvoriUlaznuRampu()
        {
            arduino.upisiIzlaz(3, 1);
        }
        public void zatvoriUlaznuRampu()
        {
            arduino.upisiIzlaz(3, 0);
        }
        public void otvoriIzlaznuRampu()
        {
            arduino.upisiIzlaz(5, 1);
        }
        public void zatvoriIzlaznuRampu()
        {
            arduino.upisiIzlaz(5, 0);
        }
        public int zauzmiMjesto()
        {
            int i;
            for (i = 0; i < Baza.listaMjesta.Count(); i++)
                if (Baza.listaMjesta[i] == false)
                    break;
            return i;
        }
        public void oslobodiMjesto(int polozaj)
        {
            Baza.listaMjesta[polozaj] = false;
        }
    }
}
