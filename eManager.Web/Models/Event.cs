using System;

namespace eManager.Web.Models
{
    public class Event
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsActive { get; set; }
    }
}