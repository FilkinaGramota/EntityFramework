using System;
using System.Collections.Generic;
using System.Text;
using TestEFCore.Entities;

namespace TestEFCore.Repositories
{
    class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public VideoLibraryDbContext VideoLibraryContext
        {
            get { return context as VideoLibraryDbContext; }
        }

        public GenreRepository(VideoLibraryDbContext context): base(context)
        {

        }
    }
}
