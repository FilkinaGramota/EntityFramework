using System;
using System.Collections.Generic;
using System.Text;
using TestEFCore.Entities;

namespace TestEFCore.Repositories
{
    class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public VideoLibraryDbContext VideoLibraryContext
        {
            get { return context as VideoLibraryDbContext; }
        }
        public ClientRepository(VideoLibraryDbContext context):base(context)
        {

        }
    }
}
