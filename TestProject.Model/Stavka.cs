using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Model
{
    public class Stavka
    {
        [Key]
        [Required]
        public int StavkaID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Opis { get; set; }

        [Required]
        public int Kolicina { get; set; }

        [Required]
        public float Cijena { get; set; }

        [Required]
        public float UkupnaCijenaSPDVom { get; set; }
    }
}
