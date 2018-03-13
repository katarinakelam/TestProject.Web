using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestProject.Web.ViewModels
{
    public class Stavka
    {
        public string Opis { get; set; }

        public int Kolicina { get; set; }

        public float Cijena { get; set; }

        [DisplayName("Ukupna cijena s PDVom")]
        public float UkupnaCijenaSPDVom { get; set; }
    }
}