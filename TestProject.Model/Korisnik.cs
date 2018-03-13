using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Model
{
    public class Korisnik
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Ime { get; set; }

        [Key]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string KorisnickoIme { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Lozinka { get; set; }
    }
}
