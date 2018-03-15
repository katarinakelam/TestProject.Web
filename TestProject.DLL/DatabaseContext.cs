using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestProject.Model;

namespace TestProject.DLL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Stavka> Stavke { get; set; }
        public DbSet<Faktura> Fakture { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
    }
}