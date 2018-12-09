using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore.Repositories
{
    interface IBaseRepository<T> where T: class
    {
        void Add(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Delete(T entity);
    }
}
