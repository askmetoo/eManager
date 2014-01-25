using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eManager.Web.Models
{
    public interface IDepartmentDataSource
    {
        IQueryable<Employee> Employees { get; }
        IQueryable<Department> Departments { get; }
        IQueryable<Dependent> Dependents { get; }
        void Save();
    }
}