using eManager.Domain;

namespace eManager.Data
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository() : base(new eManagerContext())
        {

        }
    }
}