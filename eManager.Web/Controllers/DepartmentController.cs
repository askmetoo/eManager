using eManager.Domain;
using eManager.Web.Infrastructure;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace eManager.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentDataSource _db;

        public DepartmentController(IDepartmentDataSource db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Departments);
        }

        public ActionResult Detail(int DepartmentID)
        {
            var model = _db.Departments.Single(d => d.DepartmentID == DepartmentID);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateDepartmentViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateDepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var department = new DepartmentDb();
                department.Departments.Add(
                new Department() { Name = viewModel.Name });

                department.SaveChanges();

                return RedirectToAction("index", "Department");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int DepartmentID)
        {
            var model = _db.Departments.Single(d => d.DepartmentID == DepartmentID);
            var viewModel = new EditDepartmentViewModel() { 
                Name = model.Name,
                Categories = new SelectList(Constants.DepartmentCategory.ToList(), "Key", "Value", model.Category)
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditDepartmentViewModel viewModel, int DepartmentID)
        {
            var context = new DepartmentDb();
            var department = context.Departments.Single(d => d.DepartmentID == DepartmentID);
            department.Name = viewModel.Name;
            department.Category = viewModel.CategoryCode;
            context.SaveChanges();
            return RedirectToAction("index", "Department");
        }

        [HttpGet]
        public ActionResult Search(string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var context = _db.Departments
                                 .Where(d => d.Name.Contains(query))
                                 .Take(10);
                return View(context);
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult GetLayout()
        {
            var departmentList = _db.Departments.ToList();
            var departments = departmentList.Select(d => new DepartmentLayout()
            {
                Id = d.DepartmentID,
                Name = d.Name,
                X = d.X,
                Y = d.Y,
                Width = d.Width,
                Height = d.Height,
                EmployeeCount = d.Employees.Count()
            }).ToList();

            return Json(departments, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Layout()
        {
            return View();
        }
    }
}
