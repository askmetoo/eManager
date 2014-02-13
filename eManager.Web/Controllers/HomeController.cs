using eManager.Web.DAL;
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
        public ActionResult GetEvents()
        {
            var events = new[]
            {     
                new { title = "Here goes the event description", start = "2014-02-11 14:08:00", end = "2014-02-12 16:50:00", editable = false , url = "http://google.com/" },
                new { title = "Final Exams", start = "2014-02-12T15:09:00Z", end = "2014-02-11T17:10:00Z", editable = false , url = "http://google.com/" },
                new { title = "Cartoon Day", start = "2014-02-13T16:10:00Z", end = "2014-02-11T18:11:00Z", editable = false , url = "http://google.com/" },
                new { title = "Event 4", start = "2014-02-14T17:11:00Z", end = "2014-02-11T19:12:00Z", editable = false , url = "http://google.com/" },
                new { title = "Event 5", start = "2014-02-15T18:12:00Z", end = "2014-02-11T20:13:00Z", editable = false, url = "http://google.com/" },         
                new { title = "Event 6", start = "2014-02-16T19:13:00Z", end = "2014-02-11T21:14:00Z", editable = false, url = "http://google.com/" }
            };

            return Json(events, JsonRequestBehavior.AllowGet);
        }
    }
}