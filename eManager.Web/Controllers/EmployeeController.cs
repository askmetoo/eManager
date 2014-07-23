using eManager.Web.DAL.Repository;
using eManager.Web.Models;
using eManager.Web.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class EmployeeController : GenericController<Employee>
    {
        private IEmployeeRepository repository;

        public EmployeeController(IEmployeeRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

        [NonAction]
        public override ActionResult Index() { return View(); }

        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSort = sortOrder == "HireDate_asc" ? "HireDate_desc" : "HireDate_asc";

            var employees = from e in repository.FindAll()
                            select e;

            switch (sortOrder)
            {
                case "Name_desc":
                    employees = employees.OrderByDescending(e => e.Name);
                    break;
                case "HireDate_desc":
                    employees = employees.OrderByDescending(e => e.HireDate);
                    break;
                case "HireDate_asc":
                    employees = employees.OrderBy(e => e.HireDate);
                    break;
                default:
                    employees = employees.OrderBy(e => e.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize));

            //return View(_db.Employees);
        }

        [NonAction]
        public override ActionResult Create() { return View(); }

        [HttpGet]
        public ActionResult Create(int departmentId)
        {
            var model = new CreateEmployeeViewModel();
            model.DepartmentId = departmentId;

            return View(model);
        }

        [HttpPost]
        [NonAction]
        public override ActionResult Create(Employee employee) { return View(); }

        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //var department = repository.FindAll().Single(d => d.DepartmentID == viewModel.DepartmentId);
                var employee = new Employee();
                employee.Id = viewModel.Id;
                employee.Name = viewModel.Name;
                employee.HireDate = viewModel.HireDate;
                employee.DepartmentID = viewModel.DepartmentId;
                //department.Employees.Add(employee);

                repository.Add(employee);
                repository.Save();

                return RedirectToAction("Details", "Department", new { id = viewModel.DepartmentId });
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult GetDependents(int Id)
        {
            var dependentList = repository.FindDependents(Id);

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

        [HttpPost]
        [NonAction]
        public override ActionResult Edit(Employee employee) { return View(); }

        [HttpPost]
        public ActionResult Edit([FromJson] IEnumerable<DependentViewModel> dependents,
            [FromJson] IEnumerable<DependentViewModel> removed, Employee Employee)
        {
            if (dependents != null || removed != null)
            {
                foreach (DependentViewModel dep in dependents)
                {
                    if (!repository.FindDependents(Employee.Id).Any(d => d.Name == dep.Name && d.Age == dep.Age))
                        repository.AddDependent(new Dependent()
                        {
                            EmployeeID = dep.EmployeeID,
                            Name = dep.Name,
                            Age = dep.Age,
                            Relation = dep.Relation
                        });
                }

                foreach (DependentViewModel dep in removed)
                {
                    var deleteThis = repository.FindDependents(Employee.Id).First(d => d.Name == dep.Name && d.Age == dep.Age);
                    //context.Entry(deleteThis).State = System.Data.EntityState.Deleted;
                    repository.RemoveDependent(deleteThis);
                }

                repository.Save();
                Employee employee = repository.FindById(Employee.Id);

                return View(employee);
            }
            else if (ModelState.IsValid)
            {
                repository.Update(Employee);
                repository.Save();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Dependents(int Id)
        {
            Employee employee = repository.FindById(Id);
            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }
    }
}
