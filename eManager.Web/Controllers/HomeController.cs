﻿using eManager.Web.DAL;
using eManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SiteDataMap(int? departmentId, int? employeeId)
        {
            eManagerContext db = new eManagerContext();
            var viewModel = new SiteDataMapViewModel();

            viewModel.Departments = db.Departments.ToList();
            //.Include(e => e.Employees.Select(d => d.Department));

            if (departmentId != null)
            {
                viewModel.Employees = viewModel.Departments.Where(
                    d => d.DepartmentID == departmentId).Single().Employees;
            }

            if (employeeId != null)
            {
                var selectedEmployee = viewModel.Employees.Where(
                    e => e.EmployeeID == employeeId).Single();
                db.Entry(selectedEmployee).Collection(x => x.Dependents).Load();

                viewModel.Dependents = selectedEmployee.Dependents;
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Attachments()
        {
            var files = Directory.EnumerateFiles(Server.MapPath("~/attachments"));
            return View(files);
        }

        [HttpPost]
        public ActionResult Attachments(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Attachments");
        }
    }
}