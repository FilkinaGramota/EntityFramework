using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public Film GetFilm(string filmTitle)
        {
            return VideoLibraryContext.Films.Single(f => f.Title.Equals(filmTitle));
        }
    }
}
