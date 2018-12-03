using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore
{
    interface ICasseteRepository : IBaseRepository<Cassette>
    {
        IEnumerable<Cassette> GetCassettesMin(int amount);
        IEnumerable<Cassette> GetCassettesMax(int amout);
    }
}
