using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Practice.DataBase;
using Library_Practice.Models;

namespace Library_Practice.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class, IHasIdentity
    {
        private readonly LibraryDbContext dBContext;
        public EfRepository(LibraryDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void Delete(int id)
        {
            var item = this.dBContext.Set<T>().FirstOrDefault(x => x.Id == id);
            this.dBContext.Remove(item);

        }

        public T Get(int id)
        {
            return this.dBContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return this.dBContext.Set<T>().ToList();
        }

        public void Insert(T item)
        {
            this.dBContext.Add<T>(item);
        }

        public T Update(T item)
        {
            this.dBContext.Update(item);
            return item;
        }
        public void Save()
        {
            this.dBContext.SaveChanges();
        }
    }
}
