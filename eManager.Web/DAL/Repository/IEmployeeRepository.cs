using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eManager.Web.DAL.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        ICollection<Dependent> FindDependents(int Id);
        void AddDependent(Dependent addEntity);
        void RemoveDependent(Dependent removeEntity);
    }
}
