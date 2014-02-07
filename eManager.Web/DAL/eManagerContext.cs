using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace eManager.Web.DAL
{
    public class eManagerContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dependent> Dependents { get; set; }

        public eManagerContext() : base("DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer<eManagerContext>(new DropCreateDatabaseAlways<eManagerContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //IQueryable<Dependent> IDepartmentDataSource.Dependents 
        //{
        //    get { return Dependents; }
        //}

        //IQueryable<Employee> IDepartmentDataSource.Employees
        //{
        //    get { return Employees; }
        //}

        //IQueryable<Department> IDepartmentDataSource.Departments
        //{
        //    get { return Departments; }
        //}

        //void IDepartmentDataSource.Save()
        //{
        //    SaveChanges();
        //}
    }
}