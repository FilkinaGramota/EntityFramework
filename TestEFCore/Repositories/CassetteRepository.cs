using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestEFCore.Entities;

namespace TestEFCore.Repositories
{
    class CassetteRepository : BaseRepository<Cassette>, ICasseteRepository
    {
        public VideoLibraryDbContext VideoLibraryContext
        {
            get { return context as VideoLibraryDbContext; }
        }

        public CassetteRepository(VideoLibraryDbContext context): base(context)
        {
            
        }

        public IQueryable<Cassette> GetCassettesMin(int amount)
        {
            return VideoLibraryContext.Cassettes.Where(cassette => cassette.Amount < amount);
        }

        public IQueryable<Cassette> GetCassettesMax(int amout)
        {
            return VideoLibraryContext.Cassettes.Where(cassete => cassete.Amount >= amout);
        }

    }
}
