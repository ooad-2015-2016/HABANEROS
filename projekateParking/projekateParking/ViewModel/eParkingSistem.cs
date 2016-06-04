using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using projekateParking.BazaPodataka;
namespace projekateParking.ViewModel
{
    public class eParkingSistem
    {
        private List<Boolean> listaMjesta;
        private Arduino arduino;
        private PrepoznavanjeTablica prepoznavanjeTablica;

        public eParkingSistem()
        {
            listaMjesta = new List<bool>(100);
            arduino = new Arduino();
        }
        public async void Pokreni(CaptureElement PreviewControl)
        {
            Task.Delay(2000).Wait();
            char recenica = 'U';// arduino.ucitajZnak();
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
                Debug.WriteLine(tablice);
                Task.Delay(10000).Wait();
                List<int> prik = BazaPodataka.Baza.sistem.pronadjiKorisnikaIRegistraciju(tablice);
                if (recenica == 'U' && prik.Count() > 0)///if() u bazi podataka zapocni sesiju i otvori ulaznu rampu
                {
                    otvoriUlaznuRampu();
                    int mjesto = zauzmiMjesto();
                    BazaPodataka.Baza.sistem.listaKorisnika[prik[0]].listaRegistracija[prik[1]].dodajSesiju(new SesijaOKoristenjuParkinga(DateTime.Now, mjesto));
                    zatvoriUlaznuRampu();
                }
                else if (recenica == 'I' && prik.Count() > 0)///u bazi podataka zatvori sesiju i otvori izlaznu rampu
                {
                    otvoriIzlaznuRampu();
                    int mjesto = BazaPodataka.Baza.sistem.listaKorisnika[prik[0]].listaRegistracija[prik[1]].zatvoriSesiju();
                    oslobodiMjesto(mjesto);
                    zatvoriIzlaznuRampu();
                }
                else ///else usmjeri na registraciju
                {
                    Debug.WriteLine(tablice);
                    Debug.WriteLine("Registruj se!!");
                    Baza.textBlockPoruka = "Usmjeri na registraciju";
                }
            }
            Baza.textBlockPoruka = "KRAJ";
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
            for (i = 0; i < listaMjesta.Count(); i++)
                if (listaMjesta[i] == false)
                    break;
            return i;
        }
        public void oslobodiMjesto(int polozaj)
        {
            listaMjesta[polozaj] = false;
        }
    }
}
