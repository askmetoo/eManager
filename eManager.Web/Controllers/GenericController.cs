using eManager.Web.Models;
using eManager.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Web.ViewModels;

namespace eManager.Web.Controllers
{
    public class GenericController : Controller
    {
        //
        // GET: /Generic/

        private IDepartmentDataSource _db;

        public GenericController(IDepartmentDataSource db)
        {
            _db = db;
        }

        public ActionResult Index(string process)
        {
            if (process.Equals("Department"))
            {
                return View(_db.Departments);
            }
            else if (process.Equals("Employee"))
            {
                return View(_db.Employees);
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Create(string process)
        {
            if (process.Equals("Department"))
            {
                var model = new Department();
                return View(model);
            }
            else if (process.Equals("Employee"))
            {
                var model = new Employee();
                return View(model);
            }
            else
                return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")][ModelBinder(typeof(GenericModelBinder))] object model) 
        {
            Department d = (Department)model;

            var department = new eManagerContext();
            department.Departments.Add(
                new Department() { Name = d.Name });
            department.SaveChanges();
            //department.Entry(model).State = EntityState.Modified;
            //department.SaveChanges();
            return View(d);

            //if (ModelState.IsValid)
            //{
            //    var department = new DepartmentDb();
            //    department.Departments.Add(
            //    new Department() { Name = viewModel.Name });

            //    department.SaveChanges();

            //    return RedirectToAction("index", "Department");
            //}

            //return View(viewModel);
        }

    }
}
