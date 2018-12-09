using System;
using System.Collections.Generic;
using System.Text;
using TestEFCore.Entities;

namespace TestEFCore.Repositories
{
    interface ICasseteRepository : IBaseRepository<Cassette>
    {
        IEnumerable<Cassette> GetCassettesMin(int amount);
        IEnumerable<Cassette> GetCassettesMax(int amout);
    }
}
