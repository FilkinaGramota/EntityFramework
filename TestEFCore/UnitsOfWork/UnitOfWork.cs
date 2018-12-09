using System;
using System.Collections.Generic;
using System.Text;
using TestEFCore.Repositories;

namespace TestEFCore.UnitsOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly VideoLibraryDbContext context;

        public ICasseteRepository CassetteRep { get; set; }
        public IClientRepository ClientRep { get; set; }
        // IOderRepository
        // IFilmRepository

        public UnitOfWork(VideoLibraryDbContext context)
        {
            this.context = context;
            CassetteRep = new CassetteRepository(context);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
