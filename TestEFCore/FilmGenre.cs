using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore
{
    public class FilmGenre
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
