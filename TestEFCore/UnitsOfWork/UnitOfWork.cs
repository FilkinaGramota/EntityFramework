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
        public IOrderRepository OrderRep { get; set; }
        public IFilmRepository FilmRep { get; set; }
        public IGenreRepository GenreRep { get; set; }

        public UnitOfWork(VideoLibraryDbContext context)
        {
            this.context = context;
            CassetteRep = new CassetteRepository(context);
            ClientRep = new ClientRepository(context);
            OrderRep = new OrderRepository(context);
            FilmRep = new FilmRepository(context);
            GenreRep = new GenreRepository(context);
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
