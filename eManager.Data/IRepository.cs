using System;
using System.Linq;
using System.Linq.Expressions;

namespace eManager.Data
{
    public interface IRepository<T> : IDisposable
    {
        void Add(T addEntity);
        void Remove(T removeEntity);
        void Update(T updateEntity);
        T FindById(int id);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll();
        void Save();
    }
}
