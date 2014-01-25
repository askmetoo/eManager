using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eManager.Web.ViewModels
{
    public class GenericViewModel
    {
        public Department Department { get; set; }
        public Employee Employee { get; set; }
    }
}