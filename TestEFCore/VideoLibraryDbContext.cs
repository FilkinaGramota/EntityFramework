using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace TestEFCore
{
    public class VideoLibraryDbContext: DbContext
    {
        public DbSet<Cassette> Cassettes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Film> Films { get; set; }
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

        }
    }
}
