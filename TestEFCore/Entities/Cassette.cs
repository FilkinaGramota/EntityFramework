using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore.Entities
{
    public class Cassette
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public IEnumerable<CassetteFilm> CassetteFilms { get; set; }
        public IEnumerable<OrderCassette> OrderCassettes { get; set; }
    }
}
