using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderStart { get; set; }
        public DateTime OrderEnd { get; set; }

        public Client Client { get; set; }
        public IEnumerable<OrderCassette> OrderCassettes { get; set; }

        //// default values
        //public Order()
        //{
        //    OrderStart = DateTime.Today;
        //    Days = 3;
        //    OrderEnd = OrderStart.AddDays(Days);

        //    FilmOrders = new List<FilmOrder>();
        //}
        //// users values
        //public Order(DateTime orderStart, int days)
        //{
        //    this.OrderStart = orderStart;
        //    this.Days = days;
        //    OrderEnd = OrderStart.AddDays(Days);

        //    FilmOrders = new List<FilmOrder>();
        //}
    }
}
