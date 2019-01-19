using System;
using System.Collections.Generic;
using System.Text;
using TestEFCore.Repositories;

namespace TestEFCore.UnitsOfWork
{
    interface IUnitOfWork : IDisposable
    {
        ICasseteRepository CassetteRep { get; set; }
        IClientRepository ClientRep { get; set; }
        IOrderRepository OrderRep { get; set; }
        IFilmRepository FilmRep { get; set; }
        IGenreRepository GenreRep { get; set; }
        int Save();// complete work with repository
    }
}
