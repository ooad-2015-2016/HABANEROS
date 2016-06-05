using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekateParking.ViewModel
{
    public class SesijaOKoristenjuParkinga
    {
        static int IDsljedeci = 1;
        public DateTime vrijemeDolaska { get; set; }
        public DateTime vrijemeOdlaska { get; set; }
        public int ID { get; set; }
        public int mjesto;

        public SesijaOKoristenjuParkinga(DateTime vrijemeDolaska, int mjesto)
        {
            ID = IDsljedeci++;
            this.vrijemeDolaska = vrijemeDolaska;
            this.mjesto = mjesto;
        }
    }
}
