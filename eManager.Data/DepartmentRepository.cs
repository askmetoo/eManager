﻿using eManager.Domain;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace eManager.Data
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
            context.Departments.Remove(removeEntity);
        }

        public void Update(Department updateEntity)
        {
            context.Entry(updateEntity).State = EntityState.Modified;
        }

        public Department FindById(int id)
        {
            return context.Departments.Single(d => d.Id == id);
        }

        public IQueryable<Department> Find(Expression<Func<Department, bool>> predicate)
        {
            return context.Departments.Where(predicate);
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