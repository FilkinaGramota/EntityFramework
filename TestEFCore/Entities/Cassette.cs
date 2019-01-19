using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestEFCore.Entities
{
    public class Cassette
    {
        public int Id { get; set; }
        public string Title { get; set; } //чаще всего будет совпадать с названием фильма, но... Как пойдет
        public int Amount { get; set; }

        public IList<CassetteFilm> CassetteFilms { get; set; }
        public IList<OrderCassette> OrderCassettes { get; set; }

        public Cassette()
        {
            CassetteFilms = new List<CassetteFilm>();
            OrderCassettes = new List<OrderCassette>();
        }

        //saving data for many-to-many
        public void AddFilm(Film film)
        {
            var cassetteFilms = new CassetteFilm();
            cassetteFilms.Film = film;
            cassetteFilms.Cassette = this;
            CassetteFilms.Add(cassetteFilms);
        }

        public Cassette ReadData(TextReader reader, TextWriter writer)
        {
            if (reader == null)
                reader = Console.In;
            if (writer == null)
                writer = Console.Out;

            writer.WriteLine("\t Введите данные о кассете");

            writer.Write("Введите название кассетты: ");
            string title = reader.ReadLine();
            while (string.IsNullOrWhiteSpace(title))
            {
                writer.Write("Хоть как-то называться кассетта должна же! Включите зрение (или воображение) и попробуйте еще раз.");
                reader.ReadLine();
                writer.Write("Введите название кассетты : ");
                title = reader.ReadLine();
            }

            writer.Write("Введите количество экземпляров : ");
            int amount = 0;
            string amountString = reader.ReadLine();

            while(!int.TryParse(amountString, out amount))
            {
                writer.Write("Что-то пошло не так... Попытайтесь еще раз ввести количество кассет");
                reader.ReadLine();
                writer.Write("Введите количество экземпляров : ");
                amountString = reader.ReadLine();
            }

            return new Cassette {Title = title, Amount = amount };
        }
    }
}
