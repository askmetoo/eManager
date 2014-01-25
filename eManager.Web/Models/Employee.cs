using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace eManager.Web.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int EmployeeID { get; set; }
        public virtual int DepartmentID { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime? HireDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Dependent> Dependents { get; set; }
    }
}
