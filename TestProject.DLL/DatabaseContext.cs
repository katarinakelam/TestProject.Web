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

        static DatabaseContext()
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<DatabaseContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}