using System;
using System.Collections.Generic;
using System.Linq;
using TestEFCore.Entities;

namespace TestEFCore.Repositories
{
    interface ICasseteRepository : IBaseRepository<Cassette>
    {
        IQueryable<Cassette> GetCassettesMin(int amount);
        IQueryable<Cassette> GetCassettesMax(int amout);
    }
}
