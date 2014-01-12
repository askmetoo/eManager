using eManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eManager.Web.Models
{
    public class DependentViewModel
    {
        public int DependentID { get; set; }
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Constants.Relationship? Relation { get; set; }

        public Employee Employee { get; set; }
    }
}