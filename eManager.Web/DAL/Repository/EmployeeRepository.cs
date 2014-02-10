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
    public class EmployeeRepository : IEmployeeRepository
    {
        private eManagerContext context;

        public EmployeeRepository(eManagerContext context)
        {
            this.context = context;
        }

        public void Add(Employee addEntity)
        {
            context.Employees.Add(addEntity);
        }

        public void Remove(Employee removeEntity)
        {
            context.Employees.Remove(removeEntity);
        }

        public void Update(Employee updateEntity)
        {
            context.Entry(updateEntity).State = EntityState.Modified;
        }

        public Employee FindById(int id)
        {
            return context.Employees.Single(e => e.EmployeeID == id);
        }

        public IQueryable<Employee> Find(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> FindAll()
        {
            return context.Employees;
        }

        public ICollection<Dependent> FindDependents(int employeeId)
        {
            var employee = this.FindById(employeeId);
            return employee.Dependents;
        }

        public void AddDependent(Dependent addEntity)
        {
            DependentRepository dependentRepository = new DependentRepository(context);
            dependentRepository.Add(addEntity);
        }

        public void RemoveDependent(Dependent removeEntity)
        {
            DependentRepository dependentRepository = new DependentRepository(context);
            dependentRepository.Remove(removeEntity);
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