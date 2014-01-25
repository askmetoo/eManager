using eManager.Web.Infrastructure;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace eManager.Web.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private eManagerContext context;

        public DepartmentRepository(eManagerContext context)
        {
            this.context = context;
        }

        public void Add(Department addEntity)
        {
            context.Departments.Add(addEntity);
        }

        public void Remove(Department removeEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(Department updateEntity)
        {
            context.Entry(updateEntity).State = EntityState.Modified;
        }

        public Department FindById(int id)
        {
            return context.Departments.Single(d => d.DepartmentID == id);
        }

        public IQueryable<Department> Find(System.Linq.Expressions.Expression<Func<Department>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> FindAll()
        {
            return context.Departments;
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