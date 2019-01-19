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
        // как же без лабуды
        public int Year { get; set; }
        public FilmTypes Type { get; set; }

        // many-to-many
        public IList<CassetteFilm> CassetteFilms { get; set; }
        public IList<FilmGenre> FilmGenres { get; set; }

        public Film()
        {
            CassetteFilms = new List<CassetteFilm>();
            FilmGenres = new List<FilmGenre>();
        }

        // saving data for many-to-many
        // in pink dreams - AddRange and fantastic UI and web-app with asp.net and new computer and new brain and new eyes and etc
        public void AddGenre(Genre genre)
        {
            var filmGenre = new FilmGenre();
            filmGenre.Genre = genre;
            filmGenre.Film = this;
            FilmGenres.Add(filmGenre);
        }

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

            writer.Write("Введите год выпуска фильма : ");
            string yearString = reader.ReadLine();
            int year = 1895;
            bool fail = true;
            while (fail)
            {
                if (int.TryParse(yearString, out year))
                {
                    if (year <= 1895 || year >= DateTime.Today.Year)
                    {
                        writer.Write("Если что, то первый фильм вышел в 1895 году. И на всякий случай внимательно посмотрите на текущий год.");
                        reader.ReadLine();
                        writer.Write("Введите год выпуска фильма : ");
                        yearString = reader.ReadLine();
                    }
                    else
                        fail = false;
                }
                else
                {
                    writer.Write("Что-то странное с вашим годом...");
                    reader.ReadLine();
                    writer.Write("Введите год выпуска фильма : ");
                    yearString = reader.ReadLine();
                }                        
            }

            writer.Write("Введите тип фильма (0 - анимационный, 1 - игровой, который с человеками): ");
            string typeString = reader.ReadLine();
            FilmTypes type = FilmTypes.Fiction;
            fail = true;
            while(fail)
            {
                if (Enum.TryParse<FilmTypes>(typeString, out type))
                {
                    if (type != FilmTypes.Animation || type != FilmTypes.Fiction)
                    {
                        writer.Write("Чуть выше в скобочках написано, какие цифры можно вводить. Кофейку налить?");
                        reader.ReadLine();
                        writer.Write("Введите тип фильма : ");
                        typeString = reader.ReadLine();
                    }
                    else
                        fail = false;
                }
                else
                {
                    writer.Write("Ну Вы и тип... задали. Так дальше не пойдет.");
                    reader.ReadLine();
                    writer.Write("Введите тип фильма : ");
                    typeString = reader.ReadLine();
                }
            }

            return new Film { Title = title, Year = year, Type = type };
        }
    }
}
