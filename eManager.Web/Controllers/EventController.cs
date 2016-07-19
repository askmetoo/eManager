using eManager.Data;
using eManager.Domain;
using eManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

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
                        EventID = e.Id,
                        Title = e.Title,
                        StartDate = e.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                        EndDate = e.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                        IsEditable = false
                    }
                );
            }

            return Json(events, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GenericTest(int id)
        {
            var temp = this.repository.FindById(id);
            var t = temp.GetType().GetProperties();
            foreach (var property in t)
            {
                string tt = property.Name;
                Console.WriteLine(tt);
            }
            return View(temp);
        }

        [HttpPost]
        public ActionResult GenericTest(Event entity)
        {
            Event e = entity;
            return View(e);
        }
    }
}
