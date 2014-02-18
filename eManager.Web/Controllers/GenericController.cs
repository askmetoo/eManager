using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Web.ViewModels;
using eManager.Web.DAL.Repository;
using eManager.Web.DAL;

namespace eManager.Web.Controllers
{
    public abstract class GenericController<T> :Controller
       // where T : class
       // where TRepo : IDepartmentRepository, new()
    {
        private IRepository<T> repository;

        public GenericController(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual ActionResult Index()
        {
            var model = this.repository.FindAll();
            return View(model);
        }

    }
}
