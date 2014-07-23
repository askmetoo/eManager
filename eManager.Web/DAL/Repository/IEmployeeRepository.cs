using eManager.Web.Models;
using System.Collections.Generic;

namespace eManager.Web.DAL.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        ICollection<Dependent> FindDependents(int Id);
        void AddDependent(Dependent addEntity);
        void RemoveDependent(Dependent removeEntity);
    }
}
