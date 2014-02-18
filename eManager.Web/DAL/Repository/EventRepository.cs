using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace eManager.Web.DAL.Repository
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository() : base(new eManagerContext())
        {

        }
    }
}