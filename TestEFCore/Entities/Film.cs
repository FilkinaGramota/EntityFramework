using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public SomeGenres Genre { get; set; }
        // many-to-many
        public IEnumerable<CassetteFilm> CassetteFilms { get; set; }
        public IEnumerable<FilmGenre> FilmGenres { get; set; }

        // default title
        //public Film()
        //{
        //    Title = "Default Title";
        //    CassetteFilms = new List<FilmOrder>();
        //}

        //public Film(string title)
        //{
        //    Title = title;
        //    FilmOrders = new List<FilmOrder>();
        //}
    }
}
