using AutoMapper;
using eManager.Web.DAL.Repository;
using eManager.Web.Models;
using eManager.Web.ViewModels;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class DepartmentController : GenericController<Department>
    {
        private IDepartmentRepository repository;

        public DepartmentController(IDepartmentRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public override ActionResult Create()
        {
            var model = new CreateDepartmentViewModel();
            return View(model);
        }

        [HttpPost]
        [NonAction]
        public override ActionResult Create(Department department) { return View(); }

        [HttpPost]
        public ActionResult Create(CreateDepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department();
                Mapper.CreateMap<CreateDepartmentViewModel, Department>();
                Mapper.Map<CreateDepartmentViewModel, Department>(viewModel, department);

                repository.Add(department);
                repository.Save();

                return RedirectToAction("index", "Department");
            }

            return View(viewModel);
        }

        [HttpGet]
        public override ActionResult Edit(int Id)
        {
            var model = repository.FindById(Id);
            var viewModel = new EditDepartmentViewModel();

            Mapper.CreateMap<Department, EditDepartmentViewModel>();
            Mapper.Map<Department, EditDepartmentViewModel>(model, viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [NonAction]
        public override ActionResult Edit(Department department) { throw new NotImplementedException(); }

        [HttpPost]
        public ActionResult Edit(//[Bind(Include = "DepartmentID, Name, RowVersion")]
            EditDepartmentViewModel viewModel, int Id)
        {
            Department department = new Department();
            try
            {
                Mapper.CreateMap<EditDepartmentViewModel, Department>();
                Mapper.Map<EditDepartmentViewModel, Department>(viewModel, department);
                if (ModelState.IsValid)
                {
                    repository.Update(department);
                    repository.Save();

                    return RedirectToAction("index", "Department");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var clientValues = (Department)entry.Entity;
                var databaseValues = (Department)entry.GetDatabaseValues().ToObject();

                if (databaseValues.Name != clientValues.Name)
                    ModelState.AddModelError("Name", "Current value: "
                        + databaseValues.Name);
                ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                  + "was modified by another user after you got the original value. The "
                  + "edit operation was canceled and the current values in the database "
                  + "have been displayed. If you still want to edit this record, click "
                  + "the Save button again. Otherwise click the Back to List hyperlink.");
                viewModel.RowVersion = databaseValues.RowVersion;
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult GetLayout()
        {
            var departmentList = repository.FindAll().ToList();
            var departments = departmentList.Select(d => new DepartmentLayout()
            {
                Id = d.Id,
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
