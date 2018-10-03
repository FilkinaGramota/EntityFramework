using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore
{
    public class FilmOrder
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
