using eManager.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using eManager.Web.ViewModels;
using eManager.Web.DAL.Repository;

namespace eManager.Web.Controllers
{
    public class DependentController : Controller
    {
        private IDependentRepository repository;

        public DependentController(IDependentRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetDependents()
        {
            var dependentList = repository.FindAll();
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
            //eManagerContext context = new eManagerContext();

            foreach (Dependent dep in dependents)
            {
                if (!repository.FindAll().Any(d => d.Name == dep.Name && d.Age == dep.Age))
                    repository.Add( new Dependent() { Name = dep.Name, Age = dep.Age });
            }

            foreach (Dependent dep in removed)
            {
                var deleteThis = repository.FindAll().First(d => d.Name == dep.Name && d.Age == dep.Age);
                //context.Entry(deleteThis).State = System.Data.EntityState.Deleted;
                repository.Remove(deleteThis);
            }

            repository.Save();

            return View("Index", dependents);
        }
    }
}
