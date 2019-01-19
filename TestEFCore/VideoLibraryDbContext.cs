using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestEFCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace TestEFCore
{
    public class VideoLibraryDbContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Cassette> Cassettes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<CassetteFilm> CassetteFilms { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<OrderCassette> OrderCassettes { get; set; }

        public VideoLibraryDbContext()
        {
            Database.Migrate();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=VideoLibrary;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CassetteFilm>().HasKey(cassettefilm => new {cassettefilm.FilmId, cassettefilm.CassetteId});
            modelBuilder.Entity<FilmGenre>().HasKey(filmgenre => new { filmgenre.FilmId, filmgenre.GenreId });
            modelBuilder.Entity<OrderCassette>().HasKey(ordercassette => new { ordercassette.OrderId, ordercassette.CassetteId });
            
            // complex type
            modelBuilder.Entity<Client>().OwnsOne(
                client => client.Name,
                name =>
                {
                    name.Property(x => x.FirstName).HasColumnName("FirstName");
                    name.Property(x => x.LastName).HasColumnName("LastName");
                });

            // enum mapping
            // чтоб красивенько строчкой в базе прописывалось
            var converter = new ValueConverter<FilmTypes, string>(
                type => type.ToString(), // как записывать в базу
                str => (FilmTypes)Enum.Parse(typeof(FilmTypes), str)); // как считывать данные из базы

            modelBuilder.Entity<Film>().Property(x => x.Type).HasConversion(converter);
        }
    }
}
