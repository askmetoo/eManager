using eManager.Domain;
using System.Collections.Generic;

namespace eManager.Web.ViewModels
{
    public class BrowseOrgDataViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Dependent> Dependents { get; set; }
    }
}