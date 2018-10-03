using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework Core!");

            using (VideoLibraryDbContext db = new VideoLibraryDbContext())
            {
                //Order order1 = new Order();
                //Order order2 = new Order(DateTime.Today, 10);
                //db.Orders.Add(order1);
                //db.Orders.Add(order2);

                // take all orders
                var orders = db.Orders.ToList();

                // stupid add
                Film film1 = new Film();
                Film film2 = new Film("Kill Bill");
                Film film3 = new Film("Kill Bill 2");
                Film film4 = new Film("Frozen");
                Film film5 = new Film("2001: A Space Odyssey");
                // AddRange() instead Add(), Add(), ..., Add() ...AddAdddAdddddAaaaa
                db.Films.AddRange(new List<Film> {film3, film2, film1, film4, film5} );

                // stupid add films to order
                FilmOrder film4Order1 = new FilmOrder {Film = film4, Order = orders[0]};
                FilmOrder film5Order1 = new FilmOrder {Film = film5, Order = orders[0]};

                FilmOrder film2Order2 = new FilmOrder {Film = film2, Order = orders[1]};
                FilmOrder film3Order2 = new FilmOrder {Film = film3, Order = orders[1]};
                FilmOrder film5Order2 = new FilmOrder {Film = film5, Order = orders[1]};
                
                db.FilmOrders.AddRange(new List<FilmOrder> {film4Order1, film5Order1, film2Order2, film3Order2, film5Order2});

                db.SaveChanges();
            }
        }
    }
}
