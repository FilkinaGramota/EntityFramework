using System;
using System.Collections.Generic;
using System.Linq;
using TestEFCore.Entities;

namespace TestEFCore.Repositories
{
    interface IFilmRepository : IBaseRepository<Film>
    {
        Film GetFilm(string filmTitle);
    }
}
