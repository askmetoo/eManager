using eManager.Domain;
using System.Collections.Generic;

namespace eManager.Data
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        ICollection<Dependent> FindDependents(int Id);
        void AddDependent(Dependent addEntity);
        void RemoveDependent(Dependent removeEntity);
    }
}
