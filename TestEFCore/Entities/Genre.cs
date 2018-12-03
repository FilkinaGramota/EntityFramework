using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore
{
    public class Genre
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public IEnumerable<FilmGenre> FilmGenres { get; set; }
    }
}
