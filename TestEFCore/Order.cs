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

        public Order()
        {
            OrderEnd = OrderStart.AddDays(Days);
        }
    }
}
