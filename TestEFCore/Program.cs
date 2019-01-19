using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestEFCore.Entities;
using TestEFCore.UnitsOfWork;

namespace TestEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var comedy = new Genre { Type = "Комедия" };
            var drama = new Genre { Type = "Драма" };
            var melodrama = new Genre { Type = "Мелодрама" };
            var military = new Genre { Type = "Военный" };
            var musical = new Genre { Type = "Мюзикл" };
            var fantasy = new Genre { Type = "Фэнтези" };

            var Devchata = new Film { Title = "Девчата", Year = 1962, Type = FilmTypes.Fiction };
            Devchata.AddGenre(comedy);
            Devchata.AddGenre(melodrama);

            var Casablanca = new Film { Title = "Касабланка", Year = 1942, Type = FilmTypes.Fiction };
            Casablanca.AddGenre(drama);
            Casablanca.AddGenre(melodrama);
            Casablanca.AddGenre(military);

            var SleepingBeauty = new Film { Title = "Спящая красавица", Year = 1958, Type = FilmTypes.Animation };
            SleepingBeauty.AddGenre(musical);
            SleepingBeauty.AddGenre(melodrama);
            SleepingBeauty.AddGenre(fantasy);

            Cassette cassette1 = new Cassette {Amount = 1 , Title = "Странное собрание"};
            cassette1.AddFilm(Casablanca);
            cassette1.AddFilm(Devchata);

            Cassette cassette4 = new Cassette {Amount = 4, Title = "Коллекция Disney. Спящая красавица" };
            cassette4.AddFilm(SleepingBeauty);

            var client = new Client { Name = new Name("Таня", "Тугодубодумова") };

            var order1 = new Order { OrderStart = new DateTime(2019, 1, 14), OrderEnd = new DateTime(2019, 1, 18) };
            order1.AddCassette(cassette1);

            var order2 = new Order { OrderStart = new DateTime(2019, 1, 19), OrderEnd = new DateTime(2019, 1, 26) };
            order2.AddCassette(cassette4);

            client.AddOrder(order1);
            client.AddOrder(order2);

            order1.Close(new DateTime(2019, 1, 19));

            using (UnitOfWork unit = new UnitOfWork(new VideoLibraryDbContext()))
            {
                /*unit.GenreRep.Add(comedy);
                unit.GenreRep.Add(drama);
                unit.GenreRep.Add(melodrama);
                unit.GenreRep.Add(military);
                unit.GenreRep.Add(musical);
                unit.GenreRep.Add(fantasy);

                unit.FilmRep.Add(Devchata);
                unit.FilmRep.Add(Casablanca);
                unit.FilmRep.Add(SleepingBeauty);

                unit.CassetteRep.Add(cassette1);
                unit.CassetteRep.Add(cassette4);

                unit.ClientRep.Add(client);

                unit.OrderRep.Add(order1);
                unit.OrderRep.Add(order2);

                unit.Save();*/

                IList<Cassette> allCassettes = unit.CassetteRep.GetAll().ToList();

                Console.WriteLine("All cassettes:");
                foreach (var cassette in allCassettes)
                    Console.WriteLine($"Cassette id={cassette.Id}, amount={cassette.Amount}");

                IList<Cassette> minCassettes = unit.CassetteRep.GetCassettesMin(3).ToList();
                Console.WriteLine("Cassettes which have amount < 3 :");
                foreach (var cassette in minCassettes)
                    Console.WriteLine($"Cassette id={cassette.Id}, amount={cassette.Amount}");

                IList<Cassette> maxCassettes = unit.CassetteRep.GetCassettesMax(3).ToList();
                Console.WriteLine("Cassettes which have amount >= 3 :");
                foreach (var cassette in maxCassettes)
                    Console.WriteLine($"Cassette id={cassette.Id}, amount={cassette.Amount}");

                var film = unit.FilmRep.GetFilm("Девчата");
                var genres = unit.GenreRep.GetFilmGenres(film).ToList() ;

                Console.WriteLine($"Genres of film {film.Title}:");
                foreach (var g in genres)
                    Console.WriteLine(g.Type);

            }

            Console.ReadLine();
        }
    }
}
