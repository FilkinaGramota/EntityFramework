using System;
using System.Collections.Generic;
using System.Linq;

namespace TestEFCore.Repositories
{
    interface IBaseRepository<T> where T: class
    {
        void Add(T entity);
        T Get(int id);
        IQueryable<T> GetAll();
        void Delete(T entity);
    }
}
