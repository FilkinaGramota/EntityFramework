using System;
using System.Collections.Generic;
using System.Linq;
using TestEFCore.Entities;

namespace TestEFCore.Repositories
{
    interface IGenreRepository : IBaseRepository<Genre>
    {
        IQueryable<Genre> GetFilmGenres(Film film);
    }
}
