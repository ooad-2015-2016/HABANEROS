﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekateParking.ViewModel;

namespace projekateParking.BazaPodataka
{
    public static class Baza
    {
        public static projekateParking.ViewModel.eParking sistem = new eParking();
        public static int index;
        public static string textBlockPoruka = "";
    }
}
