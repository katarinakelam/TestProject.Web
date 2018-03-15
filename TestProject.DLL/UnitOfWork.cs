using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;

namespace TestProject.DLL
{
    public class UnitOfWork : IDisposable
    {
        private DatabaseContext context = new DatabaseContext();

        private GenericRepository<Stavka> stavkaRepository;
        public GenericRepository<Stavka> StavkaRepository
        {
            get
            {

                if (this.stavkaRepository == null)
                {
                    this.stavkaRepository = new GenericRepository<Stavka>(context);
                }
                return stavkaRepository;
            }
        }

        private GenericRepository<Faktura> fakturaRepository;
        public GenericRepository<Faktura> FakturaRepository
        {
            get
            {
                if (this.fakturaRepository == null)
                {
                    this.fakturaRepository = new GenericRepository<Faktura>(context);
                }
                return fakturaRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
