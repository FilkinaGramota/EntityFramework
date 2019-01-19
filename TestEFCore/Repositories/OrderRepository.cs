using System;
using System.Collections.Generic;
using System.Text;
using TestEFCore.Entities;

namespace TestEFCore.Repositories
{
    class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public VideoLibraryDbContext VideoLibraryContext
        {
            get { return context as VideoLibraryDbContext; }
        }

        public OrderRepository(VideoLibraryDbContext context) : base(context)
        {

        }
    }
}
