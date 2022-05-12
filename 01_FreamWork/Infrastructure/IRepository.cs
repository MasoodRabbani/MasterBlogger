using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _01_FreamWork.Domain;

namespace _01_FreamWork.Infrastructure
{
    public interface IRepository<TKey,T >where T:DomainBase<TKey>
    {
        void Create(T entity);
        List<T> GetAll();
        T Get(TKey Id);
        bool Exists(Expression<Func<T,bool>>expression);
    }
}
