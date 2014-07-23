using eManager.Web.Models;

namespace eManager.Web.DAL.Repository
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository() : base(new eManagerContext())
        {

        }
    }
}