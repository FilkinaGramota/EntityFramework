using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderStart { get; set; }
        public int Days { get; set; }
        public DateTime OrderEnd { get; set; }

        // many-to-many
        public IList<FilmOrder> FilmOrders { get; set; }

        // default values
        public Order()
        {
            OrderStart = DateTime.Today;
            Days = 3;
            OrderEnd = OrderStart.AddDays(Days);

            FilmOrders = new List<FilmOrder>();
        }
        // users values
        public Order(DateTime orderStart, int days)
        {
            this.OrderStart = orderStart;
            this.Days = days;
            OrderEnd = OrderStart.AddDays(Days);

            FilmOrders = new List<FilmOrder>();
        }
    }
}
