using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BLL.BusinessModels
{
    public class Stavka
    {
        public int StavkaID { get; set; }

        public string Opis { get; set; }

        public int Kolicina { get; set; }

        public float Cijena { get; set; }

        public float UkupnaCijena { get; set; }
    }
}
