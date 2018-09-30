using System;
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
                Order order1 = new Order();
                Order order2 = new Order(DateTime.Today, 10);

                db.Orders.Add(order1);
                db.Orders.Add(order2);
                db.SaveChanges();
            }
        }
    }
}
