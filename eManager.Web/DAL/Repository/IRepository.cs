using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eManager.Web.DAL.Repository
{
    public interface IRepository<T> : IDisposable
    {
        void Add(T addEntity);
        void Remove(T removeEntity);
        void Update(T updateEntity);
        T FindById(int id);
        IQueryable<T> Find(Expression<Func<T>> predicate);
        IQueryable<T> FindAll();
        void Save();
    }
}
