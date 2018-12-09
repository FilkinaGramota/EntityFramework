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
        // IOderRepository
        // IFilmRepository
        int Save();// complete work with repository
    }
}
