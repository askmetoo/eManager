using AutoMapper;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using eManager.Web.ViewModels;
using eManager.Web.DAL.Repository;
using eManager.Web.DAL;

namespace eManager.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository repository;

        //public DepartmentController()
        //{
        //    this.repository = new DepartmentRepository(new eManagerContext());
        //}

        public DepartmentController(IDepartmentRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.FindAll());
        }

        public ActionResult Detail(int DepartmentID)
        {
            var model = repository.FindById(DepartmentID);
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
                Department department = new Department();
                Mapper.CreateMap<CreateDepartmentViewModel, Department>();
                Mapper.Map<CreateDepartmentViewModel, Department>(viewModel, department);

                repository.Add(department);
                repository.Save();

                //var department = new eManagerContext();
                //department.Departments.Add(
                //new Department() { Name = viewModel.Name });

                //department.SaveChanges();

                return RedirectToAction("index", "Department");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int DepartmentID)
        {
            //var model = db.Departments.Single(d => d.DepartmentID == DepartmentID);
            var model = repository.FindById(DepartmentID);
            var viewModel = new EditDepartmentViewModel();
            //var viewModel = new EditDepartmentViewModel() { 
            //    DepartmentID = model.DepartmentID,
            //    Name = model.Name,
            //    RowVersion = model.RowVersion
            //    //Categories = new SelectList(Constants.DepartmentCategory.ToList(), "Key", "Value", model.Category)
            //};
            Mapper.CreateMap<Department, EditDepartmentViewModel>();
            Mapper.Map<Department, EditDepartmentViewModel>(model, viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(//[Bind(Include = "DepartmentID, Name, RowVersion")]
            EditDepartmentViewModel viewModel, int DepartmentID)
        {
            //var db = new DepartmentDb();
            //Department department = db.Departments.Single(x => x.DepartmentID == DepartmentID);
            Department department = new Department();
            try
            {
                Mapper.CreateMap<EditDepartmentViewModel, Department>();
                Mapper.Map<EditDepartmentViewModel, Department>(viewModel, department);
                if (ModelState.IsValid)
                {
                    //db.Entry(department).State = EntityState.Modified;
                    //db.SaveChanges();
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
            
            //var department = context.Departments.Single(d => d.DepartmentID == DepartmentID);
            //department.Name = viewModel.Name;
            //department.Category = viewModel.CategoryCode;
            //context.SaveChanges();
        }

        [HttpGet]
        public ActionResult Search(string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var context = 0;
                //var context = _db.Departments
                //                 .Where(d => d.Name.Contains(query))
                //                 .Take(10);
 
                return View(context);
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult GetLayout()
        {
            var departmentList = repository.FindAll().ToList();
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
