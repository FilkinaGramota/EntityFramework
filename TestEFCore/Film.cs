using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // many-to-many
        public IList<FilmOrder> FilmOrders { get; set; }

        // default title
        public Film()
        {
            Title = "Default Title";
            FilmOrders = new List<FilmOrder>();
        }

        public Film(string title)
        {
            Title = title;
            FilmOrders = new List<FilmOrder>();
        }
    }
}
