using eManager.Domain;

namespace eManager.Data
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository() : base(new eManagerContext())
        {

        }
    }
}