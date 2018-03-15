using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestProject.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestProject.DLL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Stavka> Stavke { get; set; }
        public DbSet<Faktura> Fakture { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer<DatabaseContext>(null);
        }
    }
}