using eManager.Domain;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace eManager.Data
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
            return context.Dependents.Single(d => d.DependentID == id);
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