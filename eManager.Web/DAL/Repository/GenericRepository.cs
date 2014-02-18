using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace eManager.Web.DAL.Repository
{
    public class GenericRepository<T> where T : class
    {
        private eManagerContext context;

        public GenericRepository(eManagerContext context)
        {
            this.context = context;
        }

        public void Add(T addEntity)
        {
            context.Set<T>().Add(addEntity);
        }

        public void Remove(T removeEntity)
        {
            context.Set<T>().Remove(removeEntity);
        }

        public void Update(T updateEntity)
        {
            context.Entry(updateEntity).State = EntityState.Modified;
        }

        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public IQueryable<T> FindAll()
        {
            return context.Set<T>();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}