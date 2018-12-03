using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore
{
    public class OrderCassette
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int CassetteId { get; set; }
        public Cassette Cassette { get; set; } 
    }
}
