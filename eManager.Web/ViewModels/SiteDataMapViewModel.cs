using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eManager.Web.ViewModels
{
    public class SiteDataMapViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Dependent> Dependents { get; set; }
    }
}