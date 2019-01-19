using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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

        public IQueryable<Genre> GetFilmGenres(Film film)
        {
            return VideoLibraryContext.Genres.Where(g => g.FilmGenres.Any(fg => fg.FilmId == film.Id));
        }
    }
}
