using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
