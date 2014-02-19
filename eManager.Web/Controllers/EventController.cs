using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eManager.Web.Models;
using eManager.Web.DAL;
using eManager.Web.ViewModels;
using eManager.Web.DAL.Repository;

namespace eManager.Web.Controllers
{
    public class EventController : GenericController<Event>
    {
        IEventRepository repository;
        public EventController(IEventRepository repository) : base(repository) 
        {
            this.repository = repository;
        }

        public ActionResult GetEvents()
        {
            List<EventCalendarViewModel> events = new List<EventCalendarViewModel>();

            foreach (var e in this.repository.FindAll())
            {
                events.Add(
                    new EventCalendarViewModel
                    {
                        EventID = e.EventID,
                        Title = e.Title,
                        StartDate = e.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                        EndDate = e.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                        IsEditable = false
                    }
                );
            }

            return Json(events, JsonRequestBehavior.AllowGet);
        }
    }
}
