using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace eManager.Web.Models
{
    public class Department
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual double X { get; set; }
        public virtual double Y { get; set; }
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }

        [XmlIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
