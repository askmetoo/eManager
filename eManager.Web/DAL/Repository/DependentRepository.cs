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
    public class DependentRepository : IDependentRepository
    {

        private eManagerContext context;

        public DependentRepository(eManagerContext context)
        {
            this.context = context;
        }

        public void Add(Dependent addEntity)
        {
            context.Dependents.Add(addEntity);
        }

        public void Remove(Dependent removeEntity)
        {
            context.Dependents.Remove(removeEntity);
        }

        public void Update(Dependent updateEntity)
        {
            context.Entry(updateEntity).State = EntityState.Modified;
        }

        public Dependent FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Dependent> Find(Expression<Func<Dependent, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Dependent> FindAll()
        {
            return context.Dependents;
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