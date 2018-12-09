using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public Name Name { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
