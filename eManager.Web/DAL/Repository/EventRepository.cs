using eManager.Web.Models;

namespace eManager.Web.DAL.Repository
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository() : base(new eManagerContext())
        {

        }
    }
}