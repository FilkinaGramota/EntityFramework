using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestEFCore.Entities
{
    public class Cassette
    {
        public int Id { get; set; }
        // public string Title { get; set; } чаще всего будет совпадать с названием фильма, но... Как пойдет
        public int Amount { get; set; }

        public IList<CassetteFilm> CassetteFilms { get; set; }
        public IList<OrderCassette> OrderCassettes { get; set; }

        public Cassette ReadData(TextReader reader, TextWriter writer)
        {
            if (reader == null)
                reader = Console.In;
            if (writer == null)
                writer = Console.Out;

            writer.WriteLine("\t Введите данные о кассете");
            writer.Write("Введите количество экземпляров : ");
            int amount = 0;
            string amountString = reader.ReadLine();
            bool fail = true;

            while(fail)
            {
                try
                {
                    fail = false;
                    amount = Convert.ToInt32(amountString);
                }
                catch(Exception e) when (e is FormatException || e is OverflowException)
                {
                    writer.Write("Что-то пошло не так... Попытайтесь еще раз ввести количество кассет");
                    reader.ReadLine();
                    writer.Write("Введите количество экземпляров : ");
                    amountString = reader.ReadLine();
                }
            }

            return new Cassette { Amount = amount };
        }
    }
}
