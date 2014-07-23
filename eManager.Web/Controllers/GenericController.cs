using eManager.Web.DAL.Repository;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
            var model = this.repository.FindAll().ToList();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T @entity = this.repository.FindById(id);
            if (@entity == null)
            {
                return HttpNotFound();
            }
            return View(@entity);
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Bind(Include = "Field1,Field2,Field3")] 
        public virtual ActionResult Create(T @entity)
        {
            if (ModelState.IsValid)
            {
                this.repository.Add(@entity);
                this.repository.Save();
                return RedirectToAction("Index");
            }

            return View(@entity);
        }

        public virtual ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T @entity = this.repository.FindById(id);
            if (@entity == null)
            {
                return HttpNotFound();
            }
            return View(@entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(T @entity)
        {
            if (ModelState.IsValid)
            {
                this.repository.Update(entity);
                this.repository.Save();

                return RedirectToAction("Index");
            }
            return View(@entity);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T entity = this.repository.FindById(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T entity = this.repository.FindById(id);
            this.repository.Remove(entity);
            this.repository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
