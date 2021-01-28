using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Practice.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);
        List<T> GetAll();
        void Insert(T item);
        T Update(T item);
        void Delete(int id);
        void Save();
        IQueryable<T> GetQuery();

    }
}
