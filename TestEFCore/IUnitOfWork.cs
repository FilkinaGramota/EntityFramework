using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore
{
    interface IUnitOfWork: IDisposable
    {
        ICasseteRepository CasseteRep { get; set; }
        // IOderRepository
        // IFilmRepository
        int Save();// complete work with repository
       
    }
}
