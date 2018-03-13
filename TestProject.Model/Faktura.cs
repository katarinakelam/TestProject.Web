using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Model
{
    public class Faktura
    {
        [Key]
        [Required]
        public int FakturaID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumIzdavanja { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumDospijeca { get; set; }

        public virtual List<Stavka> Stavke { get; set; }

        public float Cijena { get; set; }

        public int PDV { get; set; }

        public float CijenaSPDVom { get; set; }

        public string Korisnik { get; set; }

        public string Primatelj { get; set; }
    }
}
