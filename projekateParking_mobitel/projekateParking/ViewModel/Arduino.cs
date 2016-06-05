using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maker.RemoteWiring;
using Microsoft.Maker.Serial;
using Windows.Devices.SerialCommunication;
using System.Diagnostics;

namespace projekateParking.ViewModel
{
    public class Arduino
    {
        private IStream konekcija;

        public Arduino()
        {
            konekcija = new UsbSerial("VID_2341", "PID_0043");
            konekcija.begin(9600, SerialConfig.SERIAL_8N2);
        }

        public char ucitajZnak()
        {
            //konekcija.flush();
            int brojac = 0;
            while (konekcija.available() > 0)
               brojac++;
            //ushort a = 0;
            /*while (true)
            {
                a = konekcija.read();
                char b = Convert.ToChar(a);
                if (b == 'I' || b == 'U')
                {
                   // konekcija.end();
                    return b;
                }
                Task.Delay(1000).Wait();
            }*/
            var a = konekcija.read();
            while (a == 65535)
                a = konekcija.read();
            return Convert.ToChar(a);
        }

        public void upisiIzlaz(int izlaz, int vrijednost)
        { 
            for(int i = 0; i < 1000; i++)
                konekcija.write(Convert.ToByte('a'));
        }
    }
}
