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
            konekcija.begin(9600, SerialConfig.SERIAL_8N1);
        }

        public char ucitajZnak()
        {
            //ciscenje buffera
            while (konekcija.available() > 0) ;
            ushort a;
            while (true)
            {
                a = konekcija.read();
                char b = Convert.ToChar(a);
                if (a != 65535)
                    Debug.WriteLine(b);
                if (b == 'I' || b == 'U')
                    return b;
            }
        }

        public void upisiIzlaz(int izlaz, int vrijednost)
        {

        }
    }
}
