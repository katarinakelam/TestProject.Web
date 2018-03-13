using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BLL.BusinessModels
{
    public class Faktura
    {
        public int FakturaID { get; set; }

        public DateTime DatumIzdavanja { get; set; }

        public DateTime DatumDospijeca { get; set; }

        public List<Stavka> Stavke { get; set; }

        public float Cijena { get; set; }

        public int PDV { get; set; }

        public float CijenaSPDVom { get; set; }

        public string StvarateljRacuna { get; set; }

        public string Primatelj { get; set; }
    }
}
