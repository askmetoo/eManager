using eManager.Web.Infrastructure;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace eManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SiteDataMap(int? departmentId, int? employeeId)
        {
            DepartmentDb db = new DepartmentDb();
            var viewModel = new SiteDataMapViewModel();

            viewModel.Departments = db.Departments
                .Include(e => e.Employees.Select(d => d.Department));

            if (departmentId != null)
            {
                viewModel.Employees = viewModel.Departments.Where(
                    d => d.DepartmentID == departmentId).Single().Employees;
            }

            if (employeeId != null)
            {
                viewModel.Dependents = viewModel.Employees.Where(
                    e => e.EmployeeID == employeeId).Single().Dependents;
            }

            return View(viewModel);
        }
    }
}
