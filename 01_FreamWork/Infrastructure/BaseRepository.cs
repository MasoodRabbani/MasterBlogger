using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _01_FreamWork.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01_FreamWork.Infrastructure
{
    public class BaseRepository<TKey, T> : IRepository<TKey,T>where T:DomainBase<TKey>
    {
        private DbContext dbContext;

        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(T entity)
        {
            dbContext.Add<T>(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Any(expression);
        }

        public T Get(TKey Id)
        {
            return dbContext.Find<T>(Id);
        }

        public List<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }
    }
}
