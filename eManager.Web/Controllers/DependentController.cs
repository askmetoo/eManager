using eManager.Web.Models;
using eManager.Web.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using eManager.Web.ViewModels;

namespace eManager.Web.Controllers
{
    public class DependentController : Controller
    {
        private IDepartmentDataSource _db;

        public DependentController(IDepartmentDataSource db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult GetDependents()
        {
            //var dependents = _db.Dependents;
            //return Json(dependents, JsonRequestBehavior.AllowGet);

            var dependentList = _db.Dependents.ToList();
            var dependents = dependentList.Select(d => new DependentViewModel()
            {
                DependentID = d.DependentID,
                Name = d.Name,
                Age = d.Age,
                Relation = d.Relation,
            }).ToList();

            return Json(dependents, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([FromJson] IEnumerable<Dependent> dependents, [FromJson] IEnumerable<Dependent> removed)
        {
            eManagerContext context = new eManagerContext();

            foreach (Dependent dep in dependents)
            {
                if (!_db.Dependents.Any(d => d.Name == dep.Name && d.Age == dep.Age))
                    context.Dependents.Add( new Dependent() { Name = dep.Name, Age = dep.Age });
            }

            foreach (Dependent dep in removed)
            {
                var deleteThis = context.Dependents.First(d => d.Name == dep.Name && d.Age == dep.Age);
                //context.Entry(deleteThis).State = System.Data.EntityState.Deleted;
                context.Dependents.Remove(deleteThis);
            }

            context.SaveChanges();

            return View("Index", dependents);
        }
    }
}
