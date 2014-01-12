using eManager.Domain;
using eManager.Web.Infrastructure;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IDepartmentDataSource _db;

        public EmployeeController(IDepartmentDataSource db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Employees);
        }

        [HttpGet]
        public ActionResult Create(int departmentId)
        {
            var model = new CreateEmployeeViewModel();
            model.DepartmentId = departmentId;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var department = _db.Departments.Single(d => d.DepartmentID == viewModel.DepartmentId);
                var employee = new Employee();
                employee.EmployeeID = viewModel.EmployeeID;
                employee.Name = viewModel.Name;
                employee.HireDate = viewModel.HireDate;
                department.Employees.Add(employee);

                _db.Save();
                return RedirectToAction("Detail", "Department", new { department.DepartmentID });
            }
            
            return View(viewModel);
        }

        public ActionResult Detail(int EmployeeID)
        {
            var model = _db.Employees.Single(e => e.EmployeeID == EmployeeID);
            return View(model);
        }

        [HttpGet]
        public ActionResult GetDependents(int EmployeeID)
        {
            var dependentList = _db.Dependents.ToList().Where(e => e.EmployeeID == EmployeeID);

            var dependents = dependentList.Select(d => new DependentViewModel()
            {
                DependentID = d.DependentID,
                EmployeeID = d.EmployeeID,
                Name = d.Name,
                Age = d.Age,
                Relation = d.Relation,
            }).ToList();

            return Json(dependents, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int EmployeeID)
        {
            Employee employee = _db.Employees.Single(e => e.EmployeeID == EmployeeID);
            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit([FromJson] IEnumerable<DependentViewModel> dependents,
            [FromJson] IEnumerable<DependentViewModel> removed, Employee Employee)
        {
            try
            {
                DepartmentDb db = new DepartmentDb();

                if (dependents != null || removed != null)
                {
                    foreach (DependentViewModel dep in dependents)
                    {
                        if (!_db.Dependents.Any(d => d.Name == dep.Name && d.Age == dep.Age))
                            db.Dependents.Add(new Dependent()
                            {
                                EmployeeID = dep.EmployeeID,
                                Name = dep.Name,
                                Age = dep.Age,
                                Relation = dep.Relation
                            });
                    }

                    foreach (DependentViewModel dep in removed)
                    {
                        var deleteThis = db.Dependents.First(d => d.Name == dep.Name && d.Age == dep.Age);
                        //context.Entry(deleteThis).State = System.Data.EntityState.Deleted;
                        db.Dependents.Remove(deleteThis);
                    }

                    db.SaveChanges();
                }
                else if (ModelState.IsValid)
                {
                    
                    db.Entry(Employee).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Index");
        }
    }
}
