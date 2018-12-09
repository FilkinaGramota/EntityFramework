using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore.Entities
{
    public class CassetteFilm
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int CassetteId { get; set; }
        public Cassette Cassette { get; set; }
    }
}
