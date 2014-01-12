using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eManager.Domain
{
    public class Dependent
    {
        public virtual int DependentID { get; set; }
        public virtual int EmployeeID { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual Constants.Relationship? Relation { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
