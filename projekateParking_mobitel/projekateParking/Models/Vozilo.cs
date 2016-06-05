using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekateParking.Models
{
    public class Vozilo
    {
        public String registarskeOznake { get; set; }
        public Double tezina { get; set; }
        public String proizvodjac { get; set; }
        public String model { get; set; }
        public String vrstaVozila { get; set; }

        public Vozilo(String registarskeOznake, Double tezina, String proizvodjac, String model, String vrstaVozila)
        {
            this.registarskeOznake = registarskeOznake;
            this.tezina = tezina;
            this.proizvodjac = proizvodjac;
            this.model = model;
            this.vrstaVozila = vrstaVozila;
        }
    }
}
