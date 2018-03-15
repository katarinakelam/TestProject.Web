using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Web.ViewModels
{
    public class Faktura
    {
        [DisplayName("Datum izdavanja")]
        [DataType(DataType.Date)]
        public DateTime DatumIzdavanja { get; set; }

        [DisplayName("Datum dospijeća")]
        [DataType(DataType.Date)]
        public DateTime DatumDospijeca { get; set; }

        [DisplayName("Stavke")]
        public IEnumerable<Stavka> Stavke { get; set; }

        public float Cijena { get; set; }

        public int PDV { get; set; }

        [DisplayName("Cijena s PDVom")]
        public string CijenaSPDVom { get; set; }

        [DisplayName("Stvaratelj računa")]
        public string StvarateljRacuna { get; set; }

        [DisplayName("Primatelj")]
        public string Primatelj { get; set; }
    }
}