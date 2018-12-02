using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TestEFCore
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

        public IEnumerable<Cassette> GetCassettesMin(int amount)
        {
            return VideoLibraryContext.Cassettes.Where(cassette => cassette.Amount < amount).ToList();
        }

        public IEnumerable<Cassette> GetCassettesMax(int amout)
        {
            return VideoLibraryContext.Cassettes.Where(cassete => cassete.Amount >= amout).ToList();
        }

    }
}
