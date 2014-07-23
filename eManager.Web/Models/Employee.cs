using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace eManager.Web.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }
        public virtual int DepartmentID { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime? BirthDate { get; set; }
        public virtual DateTime? HireDate { get; set; }
        [AllowHtml]
        public virtual string Profile { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Dependent> Dependents { get; set; }

    }
}
