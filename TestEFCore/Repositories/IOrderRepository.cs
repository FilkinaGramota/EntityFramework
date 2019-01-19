using System;
using System.Collections.Generic;
using System.Text;
using TestEFCore.Entities;

namespace TestEFCore.Repositories
{
    interface IOrderRepository : IBaseRepository<Order>
    {
    }
}
