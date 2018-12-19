using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestEFCore.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // можно добавить всякой лабуды вроде: год выпуска, страна, бюджет, режиссер, оператор (тут можно закопаться, когда будут мультфильмы), композитор, звукорежиссер и т.д. и т.п. Мастер по выкапыванию ям!
        // many-to-many
        public IList<CassetteFilm> CassetteFilms { get; set; }
        public IList<FilmGenre> FilmGenres { get; set; }

        public Film ReadData(TextReader reader, TextWriter writer)
        {
            if (reader == null)
                reader = Console.In;
            if (writer == null)
                writer = Console.Out;

            writer.WriteLine("\t Введите данные о фильме");
            writer.Write("Введите название фильма : ");
            string title = reader.ReadLine();
            
            while (string.IsNullOrWhiteSpace(title))
            {
                writer.Write("Хмм... Всемирная кинобаза не может найти фильма с таким названием. Попытайтесь еще разок!");
                reader.ReadLine();
                writer.Write("Введите название фильма : ");
                title = reader.ReadLine();
            }

            return new Film { Title = title };
        }
    }
}
