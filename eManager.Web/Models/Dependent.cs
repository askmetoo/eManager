
namespace eManager.Web.Models
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
