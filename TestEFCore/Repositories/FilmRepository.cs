using System;
using System.Collections.Generic;
using System.Text;
using TestEFCore.Entities;

namespace TestEFCore.Repositories
{
    class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        public VideoLibraryDbContext VideoLibraryContext
        {
            get { return context as VideoLibraryDbContext; }
        }

        public FilmRepository(VideoLibraryDbContext context):base(context)
        {

        }
    }
}
