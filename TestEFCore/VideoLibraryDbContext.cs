using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace TestEFCore
{
    public class VideoLibraryDbContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmOrder> FilmOrders { get; set; }

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
            modelBuilder.Entity<FilmOrder>().HasKey(filmorder => new {filmorder.FilmId, filmorder.OrderId});

            //modelBuilder.Entity<FilmOrder>()
            //    .HasOne(filmOrder => filmOrder.Film)
            //    .WithMany(film => film.FilmOrders)
            //    .HasForeignKey(filmOrder => filmOrder.FilmId);

            //modelBuilder.Entity<FilmOrder>()
            //    .HasOne(filmOrder => filmOrder.Order)
            //    .WithMany(order => order.FilmOrders)
            //    .HasForeignKey(filmOrder => filmOrder.OrderId);
        }
    }
}
