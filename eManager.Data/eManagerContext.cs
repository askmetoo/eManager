using eManager.Domain;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace eManager.Data
{
    public class eManagerContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Service> Services { get; set; }

        public eManagerContext() : base("DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new eManagerInitializer());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

        }
    }
}