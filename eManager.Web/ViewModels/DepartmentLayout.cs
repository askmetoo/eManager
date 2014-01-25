using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eManager.Web.ViewModels
{
    public class DepartmentLayout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int EmployeeCount { get; set; }
    }
}