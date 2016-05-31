using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekateParking.Models
{
    public abstract class Vozilo
    {
        public String registarskeOznake { get; set; }
        public Double tezina { get; set; }
        public String proizvodjac { get; set; }
        public String model { get; set; }

        public Vozilo()
        { }

        public Vozilo(String registarskeOznake, Double tezina, String proizvodjac, String model)
        {
            this.registarskeOznake = registarskeOznake;
            this.tezina = tezina;
            this.proizvodjac = proizvodjac;
            this.model = model;
        }
    }
}
