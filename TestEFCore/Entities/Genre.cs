using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestEFCore.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public IList<FilmGenre> FilmGenres { get; set; }

        public Genre ReadData(TextReader reader, TextWriter writer)
        {
            if (reader == null)
                reader = Console.In;
            if (writer == null)
                writer = Console.Out;

            writer.WriteLine("\t Введите данные о жанре");
            writer.Write("Введите название жанра : ");
            string type = reader.ReadLine();

            while (string.IsNullOrWhiteSpace(type))
            {
                writer.Write("Очень интересный жанр! Это тот, который в простонародье зовут черным(синим) экраном? Здесь таких не принимаем. Другой,пжлста");
                reader.ReadLine();
                writer.Write("Введите название жанра : ");
                type = reader.ReadLine();
            }

            return new Genre { Type = type };
        }
    }
}
