using eManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eManager.Web.Models
{
    public class GenericViewModel
    {
        public Department Department { get; set; }
        public Employee Employee { get; set; }
    }
}